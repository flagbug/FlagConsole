using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class GraphicBuffer
    {
        public char[,] buffer;

        /// <summary>
        /// Gets the width of this graphic buffer.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of this graphic buffer.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicBuffer"/> class.
        /// </summary>
        /// <param name="width">The width of the buffer.</param>
        /// <param name="height">The height of the buffer.</param>
        public GraphicBuffer(Size size)
        {
            this.Width = size.Width;
            this.Height = size.Height;

            this.buffer = new char[this.Width, this.Height];
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
            }
        }

        /// <summary>
        /// Draws the specified line to the specified location.
        /// </summary>
        /// <param name="line">The line to draw.</param>
        /// <param name="location">The location where the line shall be drawn.</param>
        public void DrawLine(string line, Point location)
        {
            for (int i = 0; i < line.Length; i++)
            {
                this.DrawPixel(line[i], location + new Point(i, 0));
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