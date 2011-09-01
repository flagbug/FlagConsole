using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;

namespace FlagConsole.Drawing
{
    public class Rectangle : Shape
    {
        private bool filled;
        public bool Filled
        {
            get
            {
                return this.filled;
            }

            set
            {
                this.filled = value;
            }
        }

        private Size size;
        public Size Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public Rectangle(Position position, Size size, char token, bool filled) : base(position, token)
        {
            this.size = size;
            this.filled = filled;
        }

        public override void Draw()
        {
            ConsoleColor saveForeColor = Console.ForegroundColor;
            ConsoleColor saveBackColor = Console.BackgroundColor;

            Console.ForegroundColor = this.ForeColor;
            Console.BackgroundColor = this.BackColor;

            if (this.Filled)
            {
                this.DrawFilledRectangle();
            }

            else
            {
                this.DrawNotFilledRectangle();
            }

            Console.ForegroundColor = saveForeColor;
            Console.BackgroundColor = saveBackColor;
        }

        private void DrawFilledRectangle()
        {
            HorizontalLine line = new HorizontalLine((Position)this.Position.Clone(), this.Size.Width, this.Token);
            line.BackColor = this.BackColor;
            line.ForeColor = this.ForeColor;
            
            for (int y = this.Position.Y; y < this.Position.Y + this.Size.Width; y++)
            {
                line.Draw();
                line.Position.Y++;
            }
        }

        private void DrawNotFilledRectangle()
        {
            HorizontalLine xLine = new HorizontalLine((Position)this.Position.Clone(), this.Size.Width, this.Token);
            xLine.BackColor = this.BackColor;
            xLine.ForeColor = this.ForeColor;
            xLine.Draw();
            xLine.Position.Y += this.Size.Height - 1;
            xLine.Draw();

            VerticalLine yLine = new VerticalLine((Position)this.Position.Clone(), this.Size.Height, this.Token);
            yLine.BackColor = this.BackColor;
            yLine.ForeColor = this.ForeColor;
            yLine.Draw();
            yLine.Position.X += this.Size.Width - 1;
            yLine.Draw();
        }
    }
}
