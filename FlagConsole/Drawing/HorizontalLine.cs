using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;

namespace FlagConsole.Drawing
{
    public class HorizontalLine : Line
    {
        public override void Draw()
        {
            ConsoleColor saveForeColor = Console.ForegroundColor;
            ConsoleColor saveBackColor = Console.BackgroundColor;

            Console.ForegroundColor = this.ForeColor;
            Console.BackgroundColor = this.BackColor;

            string line = "";

            for (int i = 0; i < this.Lenght; i++)
            {
                line += this.Token.ToString();
            }

            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(line);

            Console.ForegroundColor = saveForeColor;
            Console.BackgroundColor = saveBackColor;
        }

        public HorizontalLine(Position position, int lenght, char token)
            : base(position, lenght, token)
        {

        }
    }
}
