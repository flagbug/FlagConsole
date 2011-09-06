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
        /// Gets the size of the buffer.
        /// </summary>
        public Size Size { get; private set; }

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
            this.Size = size;

            this.buffer = new Pixel[this.Size.Width, this.Size.Height];

            this.Clear();
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
        /// Clears the graphic buffer and resets the drawing colors.
        /// </summary>
        public void Clear()
        {
            this.ResetColor();

            this.TraversePixels((x, y) =>
                {
                    this.DrawPixel(' ', new Coordinate(x, y));
                });
        }

        /// <summary>
        /// Merges the specified buffer at the specified location into this buffer.
        /// </summary>
        /// <param name="otherBuffer">The other buffer.</param>
        /// <param name="location">The location.</param>
        public void Merge(GraphicBuffer otherBuffer, Coordinate location)
        {
            var fColor = this.ForegroundDrawingColor;
            var bColor = this.BackgroundDrawingColor;

            otherBuffer.TraversePixels((x, y) =>
                {
                    this.ForegroundDrawingColor = otherBuffer.buffer[x, y].ForegroundColor;
                    this.BackgroundDrawingColor = otherBuffer.buffer[x, y].BackgroundColor;

                    this.DrawPixel(otherBuffer.buffer[x, y].Token, location + new Coordinate(x, y));
                });

            this.ForegroundDrawingColor = fColor;
            this.BackgroundDrawingColor = bColor;
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
                this.buffer[location.X, location.Y] = new Pixel(pixel, this.ForegroundDrawingColor, this.BackgroundDrawingColor);
            }
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
        /// Draws the specified line to the specified location.
        /// </summary>
        /// <param name="line">The line to draw.</param>
        /// <param name="location">The location where the line shall be drawn.</param>
        public void DrawLine(char[] line, Coordinate location)
        {
            for (int i = 0; i < line.Length; i++)
            {
                this.DrawPixel(line[i], location + new Coordinate(i, 0));
            }
        }

        /// <summary>
        /// Draws the buffer at the specified location to the screen.
        /// </summary>
        /// <param name="location">The location.</param>
        public void DrawToScreen(Coordinate location)
        {
            for (int y = 0; y <= this.buffer.GetUpperBound(1); y++)
            {
                Pixel[] pixels = new Pixel[this.buffer.GetUpperBound(0) + 1];

                for (int x = 0; x <= this.buffer.GetUpperBound(0); x++)
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
                        && pixel.ForegroundColor != prevPixel.ForegroundColor)
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

                    var l = pixelLine.Select(pixel => pixel.Token).ToArray();
                    Console.Write(l);
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
        private bool IsInBounds(Coordinate point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                return false;
            }

            return this.buffer.GetUpperBound(0) >= point.X && this.buffer.GetUpperBound(1) >= point.Y;
        }

        /// <summary>
        /// Calls the specified action for each pixel.
        /// </summary>
        /// <param name="action">The action.</param>
        private void TraversePixels(Action<int, int> action)
        {
            int yBound = this.buffer.GetUpperBound(1);
            int xBound = this.buffer.GetUpperBound(0);

            for (int y = 0; y <= yBound; y++)
            {
                for (int x = 0; x <= xBound; x++)
                {
                    action(x, y);
                }
            }
        }
    }
}