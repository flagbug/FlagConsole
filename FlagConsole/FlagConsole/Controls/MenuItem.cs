namespace FlagConsole.Controls
{
    /// <summary>
    /// An menu item for selection
    /// </summary>
    public class MenuItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="value">The value.</param>
        public MenuItem(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the name that is displayed in the menu.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The value of the item, returned when the user selects an item.
        /// </summary>
        public T Value { get; private set; }
    }
}