using System;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides data for the events that are raised by the <see cref="Menu"/> class
    /// </summary>
    /// <typeparam name="T">Type of the MenuItem</typeparam>
    public class MenuEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public MenuItem<T> Item { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public MenuEventArgs(MenuItem<T> item)
        {
            this.Item = item;
        }
    }
}