using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a list view, that displays items in a table with one column
    /// </summary>
    /// <typeparam name="T">Type of the item that gets displayed</typeparam>
    public class ListView<T> : ListControl
    {
        private Collection<T> items = new Collection<T>();

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ICollection<T> Items
        {
            get { return this.items; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListView&lt;T&gt;"/> class.
        /// </summary>
        public ListView()
        {
            this.Bullet = '+';
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                System.Console.SetCursorPosition(this.AbsoluteLocation.X, this.AbsoluteLocation.Y + i);

                string bulletString = this.DisplayBullets ? this.Bullet + " " : String.Empty;
                System.Console.Write(bulletString + this.items[i].ToString());
            }
        }
    }
}