﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphicBuffer.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the GraphicBuffer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Drawing
{
    using System;
    using System.Collections.Generic;

    public class GraphicBuffer
    {
        #region Fields

        private readonly Pixel[,] buffer;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicBuffer"/> class.
        /// </summary>
        /// <param name="size">The size of the buffer.</param>
        public GraphicBuffer(Size size)
        {
            this.Size = size;

            this.buffer = new Pixel[this.Size.Width, this.Size.Height];

            this.Clear();
        }

        #endregion

        /// <summary>
        /// Gets or sets the background drawing color.
        /// </summary>
        /// <value>
        /// The background drawing color.
        /// </value>
        public ConsoleColor BackgroundDrawingColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground drawing color.
        /// </summary>
        /// <value>
        /// The foreground drawing color.
        /// </value>
        public ConsoleColor ForegroundDrawingColor { get; set; }

        /// <summary>
        /// Gets the size of the buffer.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Clears the graphic buffer and resets the drawing colors.
        /// </summary>
        public void Clear()
        {
            this.ResetColor();

            this.TraversePixels((x, y) => this.DrawPixel(' ', new Coordinate(x, y)));
        }

        /// <summary>
        /// Draws a ellipse.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="midPoint">The mid point.</param>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        public void DrawEllipse(char token, Coordinate midPoint, int a, int b)
        {
            var ellipse = new Ellipse(midPoint, a, b, token);
            ellipse.Draw(this);
        }

        /// <summary>
        /// Draws the specified line to the specified location.
        /// </summary>
        /// <param name="line">The line to draw.</param>
        /// <param name="location">The location where the line shall be drawn.</param>
        public void DrawLine(string line, Coordinate location)
        {
            this.DrawLine(line.ToCharArray(), location);
        }

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        public void DrawLine(char token, Coordinate startPoint, Coordinate endPoint)
        {
            var line = new Line(startPoint, endPoint, token);
            line.Draw(this);
        }

        /// <summary>
        /// Draws the specified line to the specified location.
        /// </summary>
        /// <param name="line">The line to draw.</param>
        /// <param name="location">The location where the line shall be drawn.</param>
        public void DrawLine(char[] line, Coordinate location)
        {
            for (var i = 0; i < line.Length; i++)
            {
                this.DrawPixel(line[i], location + new Coordinate(i, 0));
            }
        }

        /// <summary>
        /// Draws the specified pixel at the specified location in the buffer.
        /// </summary>
        /// <param name="pixel">The pixel to draw.</param>
        /// <param name="location">The location where the pixel shall be drawn.</param>
        public void DrawPixel(char pixel, Coordinate location)
        {
            if (this.IsInBounds(location))
            {
                this.buffer[location.X, location.Y] = new Pixel(
                                                                pixel,
                                                                this.ForegroundDrawingColor,
                                                                this.BackgroundDrawingColor);
            }
        }

        /// <summary>
        /// Draws a rectangle.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="isFilled">if set to true [is filled].</param>
        public void DrawRectangle(char token, Coordinate location, Size size, bool isFilled)
        {
            var rectangle = new Rectangle(location, size, token, isFilled);
            rectangle.Draw(this);
        }

        /// <summary>
        /// Draws the buffer at the specified location to the screen.
        /// </summary>
        /// <param name="location">The location.</param>
        public void DrawToScreen(Coordinate location)
        {
            for (var y = 0; y < this.Size.Height; y++)
            {
                var pixels = new Pixel[this.Size.Width];

                for (var x = 0; x < this.Size.Width; x++)
                {
                    pixels[x] = this.buffer[x, y];
                }

                /*
                 * Go through each row and group pixel with the same color together.
                 * This drastically improves performance when the graphic buffer contains pixel with different colors.
                 */
                var final = new List<List<Pixel>>();
                var currentGroup = new List<Pixel>();
                Pixel prevPixel = null;

                foreach (var pixel in pixels)
                {
                    if (prevPixel != null
                     && (pixel.BackgroundColor != prevPixel.BackgroundColor
                      || pixel.ForegroundColor != prevPixel.ForegroundColor))
                    {
                        final.Add(currentGroup);
                        currentGroup = new List<Pixel>();
                    }

                    currentGroup.Add(pixel);
                    prevPixel = pixel;
                }

                if (currentGroup.Count > 0)
                {
                    final.Add(currentGroup);
                }

                Console.SetCursorPosition(location.X, location.Y + y);

                foreach (var pixelLine in final)
                {
                    // The whole line has the same color, therefore we select the color of the first item
                    var newForegroundColor = pixelLine[0].ForegroundColor;

                    if (Console.ForegroundColor != newForegroundColor)
                    {
                        Console.ForegroundColor = newForegroundColor;
                    }

                    var newBackgroundColor = pixelLine[0].BackgroundColor;

                    if (Console.BackgroundColor != newBackgroundColor)
                    {
                        Console.BackgroundColor = newBackgroundColor;
                    }

                    var line = new char[pixelLine.Count];

                    for (var i = 0; i < line.Length; i++)
                    {
                        line[i] = pixelLine[i].Token;
                    }

                    Console.Write(line);
                }
            }
        }

        /// <summary>
        /// Merges the specified buffer at the specified location into this buffer.
        /// </summary>
        /// <param name="otherBuffer">The buffer, that should be merged into this instance.</param>
        /// <param name="location">The location.</param>
        public void Merge(GraphicBuffer otherBuffer, Coordinate location)
        {
            var fColor = this.ForegroundDrawingColor;
            var bColor = this.BackgroundDrawingColor;

            otherBuffer.TraversePixels(
                                       (x, y) =>
                                       {
                                           this.ForegroundDrawingColor = otherBuffer.buffer[x, y].ForegroundColor;
                                           this.BackgroundDrawingColor = otherBuffer.buffer[x, y].BackgroundColor;

                                           this.DrawPixel(
                                                          otherBuffer.buffer[x, y].Token,
                                                          location + new Coordinate(x, y));
                                       });

            this.ForegroundDrawingColor = fColor;
            this.BackgroundDrawingColor = bColor;
        }

        /// <summary>
        /// Sets the foreground and background drawing colors to their default values.
        /// </summary>
        public void ResetColor()
        {
            Console.ResetColor();
            this.ForegroundDrawingColor = Console.ForegroundColor;
            this.BackgroundDrawingColor = Console.BackgroundColor;
        }

        /// <summary>
        /// Determines whether the specified point is in the bounds of the buffer.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// true if the specified point is in the bounds of the buffer; otherwise, false.
        /// </returns>
        private bool IsInBounds(Coordinate point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                return false;
            }

            return this.Size.Width > point.X && this.Size.Height > point.Y;
        }

        /// <summary>
        /// Calls the specified action for each pixel.
        /// </summary>
        /// <param name="action">The action.</param>
        private void TraversePixels(Action<int, int> action)
        {
            for (var y = 0; y < this.Size.Height; y++)
            {
                for (var x = 0; x < this.Size.Width; x++)
                {
                    action(x, y);
                }
            }
        }
    }
}
