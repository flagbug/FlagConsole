namespace FlagConsole.Drawing
{
    /// <summary>
    /// Base class for rectangles, lines, etc...
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets the token of which the shape consists.
        /// </summary>
        /// <value>
        /// The token of which the shape consists.
        /// </value>
        public char Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="token">The token of whih the shape consists.</param>
        protected Shape(char token)
        {
            this.Token = token;
        }

        /// <summary>
        /// Draws the shape.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        public abstract void Draw(GraphicBuffer buffer);
    }
}