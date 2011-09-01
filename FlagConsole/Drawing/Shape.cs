using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;

namespace FlagConsole.Drawing
{
    public abstract class Shape
    {
        private ConsoleColor foreColor = ConsoleColor.Gray;
        public ConsoleColor ForeColor
        {
            get
            {
                return this.foreColor;
            }

            set
            {
                this.foreColor = value;
            }
        }

        private ConsoleColor backColor = ConsoleColor.Black;
        public ConsoleColor BackColor
        {
            get
            {
                return this.backColor;
            }

            set
            {
                this.backColor = value;
            }
        }

        private Position position;
        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        private char token;
        public char Token
        {
            get
            {
                return this.token;
            }

            set
            {
                this.token = value;
            }
        }

        public abstract void Draw();

        public Shape(Position position, char token)
        {
            this.position = position;
            this.token = token;
        }
    }
}
