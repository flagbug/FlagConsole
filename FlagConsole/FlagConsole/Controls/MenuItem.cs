// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   An menu item for selection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    /// <summary>
    /// An menu item for selection
    /// </summary>
    public class MenuItem<T>
    {
        #region Constructors and Destructors

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

        #endregion

        /// <summary>
        /// Gets the name that is displayed in the menu.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value of the item, returned when the user selects an item.
        /// </summary>
        public T Value { get; private set; }
    }
}
