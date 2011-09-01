using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Controls;

namespace FlagConsole.Controls
{
    public abstract class Screen : Container
    {
        public override Util.Position AbsolutePosition
        {
            get
            {
                return this.RelativePosition;
            }

            set
            {
                base.AbsolutePosition = value;
            }
        }
    }
}
