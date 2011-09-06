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
        {/*
            Line xLine = new Line(this.Location, new Coordinate(this.Location.X + this.Size.Width - 1, this.Location.Y), this.Token);
            xLine.Draw();
            xLine.StartPoint = new Coordinate(xLine.StartPoint.X, xLine.StartPoint.Y + this.Size.Height);
            xLine.EndPoint = new Coordinate(xLine.EndPoint.X, xLine.EndPoint.Y + this.Size.Height);
            xLine.Draw();

            Line yLine = new Line(this.Location, new Coordinate(this.Location.X, this.Location.Y + this.Size.Height), this.Token);
            yLine.Draw();
            yLine.StartPoint = new Coordinate(yLine.StartPoint.X + this.Size.Width - 1, yLine.StartPoint.Y);
            yLine.EndPoint = new Coordinate(yLine.EndPoint.X + this.Size.Width - 1, yLine.EndPoint.Y);
            yLine.Draw();*/
        }
    }
}