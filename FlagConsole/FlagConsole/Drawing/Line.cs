using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;

namespace FlagConsole.Drawing
{
    public abstract class Line : Shape
    {
        private int lenght;
        public int Lenght
        {
            get
            {
                return this.lenght;
            }

            set
            {
                this.lenght = value;
            }
        }

        public Line(Position position, int lenght, char token)
            : base(position, token)
        {
            this.lenght = lenght;
        }
    }
}
