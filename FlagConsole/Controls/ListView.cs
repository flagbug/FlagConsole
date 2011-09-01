using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagConsole.Controls
{
    public class ListView<T> : Control
    {
        private List<T> items = new List<T>();
        public List<T> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }

        protected override void Show()
        {
            for(int i = 0; i < this.items.Count; i++)
            {
                Console.SetCursorPosition(this.AbsolutePosition.X, this.AbsolutePosition.Y + i);
                System.Console.Write(this.items[i].ToString());
            }
        }
    }
}
