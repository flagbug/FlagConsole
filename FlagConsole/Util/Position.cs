using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagConsole.Util
{
    /// <summary>
    /// A simple encapsulation of a x- and y-coordinate
    /// </summary>
    public class Position : ICloneable
    {
        /// <summary>
        /// private x-coordinate
        /// </summary>
        private int x;
        /// <summary>
        /// x-coordinate, get/set
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// private y-coordinate
        /// </summary>
        private int y;
        /// <summary>
        /// y-coordinate, get/set
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Initialises a position with the coordinates (0|0)
        /// </summary>
        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }

        /// <summary>
        /// Initialises a position with the passed coordinates
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public object Clone()
        {
            return new Position(this.X, this.Y);
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }
    }
}
