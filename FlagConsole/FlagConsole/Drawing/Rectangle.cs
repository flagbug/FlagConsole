using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Rectangle"/> is filled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if filled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFilled { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Coordinate Location { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="token">The token.</param>
        /// <param name="filled">if set to <c>true</c>, the rectangle is filled.</param>
        public Rectangle(Coordinate location, Size size, char token, bool filled)
            : base(token)
        {
            this.Location = location;
            this.Size = size;
            this.IsFilled = filled;
        }

        /// <summary>
        /// Draws this rectangle.
        /// </summary>
        public override void Draw(GraphicBuffer buffer)
        {
            if (this.IsFilled)
            {
                this.DrawFilledRectangle(buffer);
            }

            else
            {
                this.DrawUnfilledRectangle(buffer);
            }
        }

        /// <summary>
        /// Draws a filled rectangle.
        /// </summary>
        private void DrawFilledRectangle(GraphicBuffer buffer)
        {
            for (int y = this.Location.Y - 1; y < this.Location.Y + this.Size.Height - 1; y++)
            {
                buffer.DrawLine(this.Location + new Coordinate(0, y + 1), new Coordinate(this.Location.X + this.Size.Width - 1, this.Location.Y), this.Token);
            }
        }

        /// <summary>
        /// Draws a unfilled rectangle.
        /// </summary>
        private void DrawUnfilledRectangle(GraphicBuffer buffer)
        {
            buffer.DrawLine(
                this.Location,
                new Coordinate(this.Location.X + this.Size.Width - 1, this.Location.Y),
                this.Token);

            buffer.DrawLine(
                new Coordinate(this.Location.X, this.Location.Y + this.Size.Height),
                new Coordinate(this.Location.X + this.Size.Width - 1, this.Location.Y),
                this.Token);

            buffer.DrawLine(
                this.Location,
                new Coordinate(this.Location.X, this.Location.Y + this.Size.Height),
                this.Token
                );

            buffer.DrawLine(
                new Coordinate(this.Location.X + this.Size.Width - 1, this.Location.Y),
                new Coordinate(this.Location.X + this.Size.Width - 1, this.Location.Y + this.Size.Height),
                this.Token
                );
        }
    }
}