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
    }
}