using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlagConsole.Drawing;
using FlagConsole.Measure;

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
            GraphicBuffer buffer = new GraphicBuffer(this.Size);

            for (int i = 0; i < this.items.Count && i < this.Size.Height; i++)
            {
                string bulletString = this.DisplayBullets ? this.Bullet + " " : String.Empty;

                buffer.DrawLine(bulletString + this.items[i].ToString(), new Coordinate(0, i));
            }

            buffer.DrawToScreen(this.AbsoluteLocation);
        }
    }
}