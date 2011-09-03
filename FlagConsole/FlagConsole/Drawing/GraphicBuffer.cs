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
        public GraphicBuffer(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.buffer = new char[width, height];
        }

        /*
        public void DrawPixel(char pixel, Point location)
        {
            if (this.IsInBounds(location))
            {
            }
        }
        */

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