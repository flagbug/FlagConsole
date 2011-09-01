using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagConsole.Util
{
    public class Size : ICloneable
    {
        private int height;
        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        private int width;
        /// <summary>
        /// Gets or sets the width
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public Size()
        {
            this.height = 0;
            this.width = 0;
        }

        public Size(int width, int height)
        {
            this.height = height;
            this.width = width;
        }

        public object Clone()
        {
            return new Size(this.height, this.width);
        }
    }
}
