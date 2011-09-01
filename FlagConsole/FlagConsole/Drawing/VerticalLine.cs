using System;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    /// <summary>
    /// Represents a vertical line
    /// </summary>
    public class VerticalLine : Line
    {
        /// <summary>
        /// Draws the line.
        /// </summary>
        public override void Draw()
        {
            ConsoleColor saveForeColor = System.Console.ForegroundColor;
            ConsoleColor saveBackColor = System.Console.BackgroundColor;

            System.Console.ForegroundColor = this.ForegroundColor;
            System.Console.BackgroundColor = this.BackgroundColor;

            for (int y = this.Location.Y; y < this.Location.Y + this.Length; y++)
            {
                System.Console.SetCursorPosition(this.Location.X, y);
                System.Console.Write(this.Token);
            }

            System.Console.ForegroundColor = saveForeColor;
            System.Console.BackgroundColor = saveBackColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalLine"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="length">The lenght.</param>
        /// <param name="token">The token.</param>
        public VerticalLine(Point location, int length, char token)
            : base(location, length, token)
        {
        }
    }
}