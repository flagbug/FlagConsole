using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class Rectangle : Shape
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
        public Point Location { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="token">The token.</param>
        /// <param name="filled">if set to <c>true</c>, the rectangle is filled.</param>
        public Rectangle(Point location, Size size, char token, bool filled)
            : base(token)
        {
            this.Location = location;
            this.Size = size;
            this.IsFilled = filled;
        }

        /// <summary>
        /// Draws this rectangle.
        /// </summary>
        public override void Draw()
        {
            if (this.IsFilled)
            {
                this.DrawFilledRectangle();
            }

            else
            {
                this.DrawUnfilledRectangle();
            }
        }

        /// <summary>
        /// Draws a filled rectangle.
        /// </summary>
        private void DrawFilledRectangle()
        {
            Line line = new Line(this.Location, new Point(this.Location.X + this.Size.Width - 1, this.Location.Y), this.Token);

            for (int y = this.Location.Y - 1; y < this.Location.Y + this.Size.Height - 1; y++)
            {
                line.StartPoint = new Point(line.StartPoint.X, y + 1);
                line.EndPoint = new Point(line.EndPoint.X, y + 1);
                line.Draw();
            }
        }

        /// <summary>
        /// Draws a unfilled rectangle.
        /// </summary>
        private void DrawUnfilledRectangle()
        {
            Line xLine = new Line(this.Location, new Point(this.Location.X + this.Size.Width - 1, this.Location.Y), this.Token);
            xLine.Draw();
            xLine.StartPoint = new Point(xLine.StartPoint.X, xLine.StartPoint.Y + this.Size.Height);
            xLine.EndPoint = new Point(xLine.EndPoint.X, xLine.EndPoint.Y + this.Size.Height);
            xLine.Draw();

            Line yLine = new Line(this.Location, new Point(this.Location.X, this.Location.Y + this.Size.Height), this.Token);
            yLine.Draw();
            yLine.StartPoint = new Point(yLine.StartPoint.X + this.Size.Width - 1, yLine.StartPoint.Y);
            yLine.EndPoint = new Point(yLine.EndPoint.X + this.Size.Width - 1, yLine.EndPoint.Y);
            yLine.Draw();
        }
    }
}