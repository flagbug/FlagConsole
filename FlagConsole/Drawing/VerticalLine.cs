using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;

namespace FlagConsole.Drawing
{
    public class VerticalLine : Line
    {
        public override void Draw()
        {
            ConsoleColor saveForeColor = Console.ForegroundColor;
            ConsoleColor saveBackColor = Console.BackgroundColor;

            Console.ForegroundColor = this.ForeColor;
            Console.BackgroundColor = this.BackColor;

            for(int y = this.Position.Y; y < this.Position.Y + this.Lenght; y++)
            {
                Console.SetCursorPosition(this.Position.X, y);
                Console.Write(this.Token);
            }

            Console.ForegroundColor = saveForeColor;
            Console.BackgroundColor = saveBackColor;
        }

        public VerticalLine(Position position, int lenght, char token)
            : base(position, lenght, token)
        {

        }
    }
}
