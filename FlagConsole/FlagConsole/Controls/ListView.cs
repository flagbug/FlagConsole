using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a list view, that displays items in a table with one column
    /// </summary>
    /// <typeparam name="T">Type of the item that gets displayed</typeparam>
    public class ListView<T> : Control
    {
        private Collection<T> items = new Collection<T>();

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public ICollection<T> Items
        {
            get { return this.items; }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                System.Console.SetCursorPosition(this.AbsoluteLocation.X, this.AbsoluteLocation.Y + i);
                System.Console.Write(this.items[i].ToString());
            }
        }
    }
}