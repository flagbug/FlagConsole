using FlagConsole.Drawing;
using FlagConsole.Measure;

namespace FlagConsole.Console.Drawing
{
    /// <summary>
    /// Base class for lines (horizontal line and vertical line)
    /// </summary>
    public abstract class Line : Shape, IArea
    {
        /// <summary>
        /// Gets or sets the lenght.
        /// </summary>
        /// <value>The lenght.</value>
        public virtual int Length { get; set; }

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>The area.</value>
        public int Area
        {
            get { return this.Length; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="length">The lenght.</param>
        /// <param name="token">The token.</param>
        protected Line(Position position, int length, char token)
            : base(position, token)
        {
            this.Length = length;
        }
    }
}