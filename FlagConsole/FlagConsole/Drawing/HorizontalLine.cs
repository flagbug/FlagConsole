using System;
using System.Linq;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    /// <summary>
    /// Represents a horizontal line
    /// </summary>
    public class HorizontalLine : Line
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

            string line = new string(Enumerable.Repeat(this.Token, this.Length).ToArray());

            System.Console.SetCursorPosition(this.Location.X, this.Location.Y);
            System.Console.Write(line);

            System.Console.ForegroundColor = saveForeColor;
            System.Console.BackgroundColor = saveBackColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HorizontalLine"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="length">The lenght.</param>
        /// <param name="token">The token.</param>
        public HorizontalLine(Point location, int length, char token)
            : base(location, length, token)
        {
        }
    }
}