using System;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class Rectangle : Shape, IArea
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Rectangle"/> is filled.
        /// </summary>
        /// <value><c>true</c> if filled; otherwise, <c>false</c>.</value>
        public bool IsFilled { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size { get; set; }

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>The area.</value>
        public int Area
        {
            get { return this.Size.Height * this.Size.Width; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="token">The token.</param>
        /// <param name="filled">if set to <c>true</c>, the rectangle is filled.</param>
        public Rectangle(Point location, Size size, char token, bool filled)
            : base(location, token)
        {
            this.Size = size;
            this.IsFilled = filled;
        }

        /// <summary>
        /// Draws this rectangle.
        /// </summary>
        public override void Draw()
        {
            ConsoleColor saveForeColor = System.Console.ForegroundColor;
            ConsoleColor saveBackColor = System.Console.BackgroundColor;

            System.Console.ForegroundColor = this.ForegroundColor;
            System.Console.BackgroundColor = this.BackgroundColor;

            if (this.IsFilled)
            {
                this.DrawFilledRectangle();
            }

            else
            {
                this.DrawUnfilledRectangle();
            }

            System.Console.ForegroundColor = saveForeColor;
            System.Console.BackgroundColor = saveBackColor;
        }

        /// <summary>
        /// Draws a filled rectangle.
        /// </summary>
        private void DrawFilledRectangle()
        {
            HorizontalLine line = new HorizontalLine(this.Location, this.Size.Width, this.Token);
            line.BackgroundColor = this.BackgroundColor;
            line.ForegroundColor = this.ForegroundColor;

            for (int y = this.Location.Y; y < this.Location.Y + this.Size.Width; y++)
            {
                line.Draw();
                line.Location = new Point(line.Location.X, line.Location.Y + 1);
            }
        }

        /// <summary>
        /// Draws a unfilled rectangle.
        /// </summary>
        private void DrawUnfilledRectangle()
        {
            HorizontalLine xLine = new HorizontalLine(this.Location, this.Size.Width, this.Token);
            xLine.BackgroundColor = this.BackgroundColor;
            xLine.ForegroundColor = this.ForegroundColor;
            xLine.Draw();
            xLine.Location = new Point(xLine.Location.X, xLine.Location.Y + this.Size.Height - 1);
            xLine.Draw();

            VerticalLine yLine = new VerticalLine(this.Location, this.Size.Height, this.Token);
            yLine.BackgroundColor = this.BackgroundColor;
            yLine.ForegroundColor = this.ForegroundColor;
            yLine.Draw();
            yLine.Location = new Point(yLine.Location.X + this.Size.Width - 1, yLine.Location.Y);
            yLine.Draw();
        }
    }
}