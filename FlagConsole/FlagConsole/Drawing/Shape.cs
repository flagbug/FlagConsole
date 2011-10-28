namespace FlagConsole.Drawing
{
    /// <summary>
    /// Base class for rectangles, lines, etc...
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public char Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        protected Shape(char token)
        {
            this.Token = token;
        }

        /// <summary>
        /// Draws the shape.
        /// </summary>
        /// <param name="buffer">The graphic buffer.</param>
        public abstract void Draw(GraphicBuffer buffer);
    }
}