using System;

namespace FlagConsole.Drawing
{
    /// <summary>
    /// Base class for rectangles, lines, etc...
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Gets or sets the fore color.
        /// </summary>
        /// <value>
        /// The fore color.
        /// </value>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the back color.
        /// </summary>
        /// <value>
        /// The back color.
        /// </value>
        public ConsoleColor BackgroundColor { get; set; }

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
        /// <param name="location">The position.</param>
        /// <param name="token">The token.</param>
        protected Shape(char token)
        {
            this.Token = token;
            this.ForegroundColor = ConsoleColor.Gray;
            this.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Draws the shape.
        /// </summary>
        public abstract void Draw();
    }
}