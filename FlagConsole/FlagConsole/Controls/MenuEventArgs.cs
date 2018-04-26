namespace FlagConsole.Controls
{
    using System;

    /// <summary>
    /// Provides data for the events that are raised by the <see cref="Menu{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The type of the MenuItem.</typeparam>
    public class MenuEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public MenuEventArgs(MenuItem<T> item)
        {
            this.Item = item;
        }

        /// <summary>
        /// Gets the item that was affected.
        /// </summary>
        /// <value>
        /// The item that was affected.
        /// </value>
        public MenuItem<T> Item { get; private set; }
    }
}
