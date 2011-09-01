namespace FlagConsole.Controls
{
    /// <summary>
    /// An menu item for selection
    /// </summary>
    public class MenuItem<T>
    {
        /// <summary>
        /// Gets or sets the name which is displayed in the menu.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Value of the item, returned when the user selects an item
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public MenuItem(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}