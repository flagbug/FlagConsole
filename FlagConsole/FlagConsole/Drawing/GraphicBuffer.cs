using System;
using System.Collections.Generic;
using System.Linq;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class GraphicBuffer
    {
        private Pixel[,] buffer;

        /// <summary>
        /// Gets the width of this graphic buffer.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of this graphic buffer.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets or sets the foreground drawing color.
        /// </summary>
        /// <value>
        /// The foreground drawing color.
        /// </value>
        public ConsoleColor ForegroundDrawingColor { get; set; }

        /// <summary>
        /// Gets or sets the background drawing color.
        /// </summary>
        /// <value>
        /// The background drawing color.
        /// </value>
        public ConsoleColor BackgroundDrawingColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicBuffer"/> class.
        /// </summary>
        /// <param name="width">The width of the buffer.</param>
        /// <param name="height">The height of the buffer.</param>
        public GraphicBuffer(Size size)
        {
            this.Width = size.Width;
            this.Height = size.Height;

            this.buffer = new Pixel[this.Width, this.Height];

            this.Clear();
        }

        /// <summary>
        /// Sets the foreground and background drawing colors to their default values.
        /// </summary>
        public void ResetColor()
        {
            this.ForegroundDrawingColor = Console.ForegroundColor;
            this.BackgroundDrawingColor = Console.BackgroundColor;
        }

        /// <summary>
        /// Clears the graphic buffer and resets the drawing colors.
        /// </summary>
        public void Clear()
        {
            this.ResetColor();

            for (int y = 0; y < this.buffer.GetUpperBound(1); y++)
            {
                for (int x = 0; x < this.buffer.GetLowerBound(0); x++)
                {
                    this.DrawPixel(' ', new Point(x, y));
                }
            }
        }

        /// <summary>
        /// Merges the specified buffer at the specified location into this buffer.
        /// </summary>
        /// <param name="otherBuffer">The other buffer.</param>
        /// <param name="location">The location.</param>
        public void Merge(GraphicBuffer otherBuffer, Point location)
        {
            var fColor = this.ForegroundDrawingColor;
            var bColor = this.BackgroundDrawingColor;

            for (int y = 0; y < otherBuffer.buffer.GetUpperBound(1); y++)
            {
                for (int x = 0; x < otherBuffer.buffer.GetLowerBound(0); x++)
                {
                    this.ForegroundDrawingColor = otherBuffer.buffer[x, y].ForegroundColor;
                    this.BackgroundDrawingColor = otherBuffer.buffer[x, y].BackgroundColor;

                    this.DrawPixel(otherBuffer.buffer[x, y].Token, location + new Point(x, y));
                }
            }

            this.ForegroundDrawingColor = fColor;
            this.BackgroundDrawingColor = bColor;
        }

        /// <summary>
        /// Draws the specified pixel at the specified location in the buffer.
        /// </summary>
        /// <param name="pixel">The pixel to draw.</param>
        /// <param name="location">The location where the pixel shall be drawn.</param>
        public void DrawPixel(char pixel, Point location)
        {
            if (this.IsInBounds(location))
            {
                this.buffer[location.X, location.Y] = new Pixel(pixel, this.ForegroundDrawingColor, this.BackgroundDrawingColor);
            }
        }

        /// <summary>
        /// Draws the specified line to the specified location.
        /// </summary>
        /// <param name="line">The line to draw.</param>
        /// <param name="location">The location where the line shall be drawn.</param>
        public void DrawLine(string line, Point location)
        {
            this.DrawLine(line, location);
        }

        /// <summary>
        /// Draws the specified line to the specified location.
        /// </summary>
        /// <param name="line">The line to draw.</param>
        /// <param name="location">The location where the line shall be drawn.</param>
        public void DrawLine(char[] line, Point location)
        {
            for (int i = 0; i < line.Length; i++)
            {
                this.DrawPixel(line[i], location + new Point(i, 0));
            }
        }

        /// <summary>
        /// Draws the buffer at the specified location to the screen.
        /// </summary>
        /// <param name="location">The location.</param>
        public void DrawToScreen(Point location)
        {
            for (int y = 0; y < this.buffer.GetUpperBound(1); y++)
            {
                Pixel[] pixels = new Pixel[this.buffer.GetUpperBound(0)];

                for (int x = 0; x < this.buffer.GetUpperBound(0); x++)
                {
                    pixels[x] = this.buffer[x, y];
                }

                var final = new List<List<Pixel>>();
                var currentGroup = new List<Pixel>();
                Pixel prevPixel = null;

                foreach (var pixel in pixels)
                {
                    if (prevPixel != null
                        && pixel.BackgroundColor != prevPixel.BackgroundColor
                        && pixel.ForegroundColor == prevPixel.ForegroundColor)
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
                    Console.ForegroundColor = pixelLine[0].ForegroundColor;
                    Console.BackgroundColor = pixelLine[0].BackgroundColor;

                    Console.Write(pixelLine.Select(pixel => pixel.Token));
                }
            }
        }

        /// <summary>
        /// Determines whether the specified point is in the bounds of the buffer.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// true if the specified point is in the bounds of the buffer; otherwise, false.
        /// </returns>
        private bool IsInBounds(Point point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                return false;
            }

            return this.buffer.GetUpperBound(0) >= point.X && this.buffer.GetUpperBound(1) >= point.Y;
        }
    }
}