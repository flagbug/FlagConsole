using System;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class GraphicBuffer
    {
        private char[,] buffer;
        private ConsoleColor[,] foregroundColorBuffer;
        private ConsoleColor[,] backgroundColorBuffer;

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
            this.ResetColor();

            this.buffer = new char[this.Width, this.Height];
            this.foregroundColorBuffer = new ConsoleColor[this.Width, this.Height];
            this.backgroundColorBuffer = new ConsoleColor[this.Width, this.Height];
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
        /// Merges the specified buffer at the specified location into this buffer.
        /// </summary>
        /// <param name="otherBuffer">The other buffer.</param>
        /// <param name="location">The location.</param>
        public void Merge(GraphicBuffer otherBuffer, Point location)
        {
            for (int y = 0; y < otherBuffer.buffer.GetUpperBound(1); y++)
            {
                for (int x = 0; x < otherBuffer.buffer.GetLowerBound(0); x++)
                {
                    this.DrawPixel(otherBuffer.buffer[x, y], location + new Point(x, y));
                }
            }
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
                this.buffer[location.X, location.Y] = pixel;
                this.foregroundColorBuffer[location.X, location.Y] = this.ForegroundDrawingColor;
                this.backgroundColorBuffer[location.X, location.Y] = this.BackgroundDrawingColor;
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
                string line = String.Empty;

                for (int x = 0; x < this.buffer.GetLowerBound(0); x++)
                {
                    line += this.buffer[x, y];
                }

                Console.SetCursorPosition(location.X, location.Y + y);
                Console.WriteLine(line);
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