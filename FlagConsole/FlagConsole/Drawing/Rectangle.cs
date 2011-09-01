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
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        /// <param name="token">The token.</param>
        /// <param name="filled">if set to <c>true</c>, the rectangle is filled.</param>
        public Rectangle(Position position, Size size, char token, bool filled)
            : base(position, token)
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
            HorizontalLine line = new HorizontalLine((Position)this.Position.Clone(), this.Size.Width, this.Token);
            line.BackgroundColor = this.BackgroundColor;
            line.ForegroundColor = this.ForegroundColor;

            for (int y = this.Position.Y; y < this.Position.Y + this.Size.Width; y++)
            {
                line.Draw();
                line.Position = new Position(line.Position.X, line.Position.Y + 1);
            }
        }

        /// <summary>
        /// Draws a unfilled rectangle.
        /// </summary>
        private void DrawUnfilledRectangle()
        {
            HorizontalLine xLine = new HorizontalLine(this.Position, this.Size.Width, this.Token);
            xLine.BackgroundColor = this.BackgroundColor;
            xLine.ForegroundColor = this.ForegroundColor;
            xLine.Draw();
            xLine.Position = new Position(xLine.Position.X, xLine.Position.Y + this.Size.Height - 1);
            xLine.Draw();

            VerticalLine yLine = new VerticalLine(this.Position, this.Size.Height, this.Token);
            yLine.BackgroundColor = this.BackgroundColor;
            yLine.ForegroundColor = this.ForegroundColor;
            yLine.Draw();
            yLine.Position = new Position(yLine.Position.X + this.Size.Width - 1, yLine.Position.Y);
            yLine.Draw();
        }
    }
}