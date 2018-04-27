// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Menu.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Provides a text-based menu in the console, where the user can select an item
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    using System;
    using System.Collections.Generic;

    using FlagConsole.Drawing;

    /// <summary>
    /// Provides a text-based menu in the console, where the user can select an item
    /// </summary>
    /// <typeparam name="T">Type of the item that the user can select</typeparam>
    public class Menu<T> : ListControl, IFocusable
    {
        #region Fields

        private readonly List<MenuItem<T>> items;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu&lt;T&gt;"/> class.
        /// </summary>
        public Menu()
        {
            this.items = new List<MenuItem<T>>();
            this.UpKeys = new HashSet<ConsoleKey> { ConsoleKey.UpArrow };
            this.DownKeys = new HashSet<ConsoleKey> { ConsoleKey.DownArrow };
            this.Bullet = '-';
            this.SelectionForegroundColor = ConsoleColor.Black;
            this.SelectionBackgroundColor = ConsoleColor.White;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a item has been chosen.
        /// </summary>
        public event EventHandler<MenuEventArgs<T>> ItemChosen;

        /// <summary>
        /// Occurs when the current selected item has changed.
        /// </summary>
        public event EventHandler<MenuEventArgs<T>> SelectionChanged;

        #endregion

        /// <summary>
        /// Gets a collection of <see cref="ConsoleKey"/>s that can be used to scroll downward in the menu.
        /// </summary>
        /// <value>
        /// A collection of <see cref="ConsoleKey"/>s that can be used to scroll downward in the menu.
        /// </value>
        public ICollection<ConsoleKey> DownKeys { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        /// <value>
        /// true if the control has input focus; otherwise, false.
        /// </value>
        public virtual bool IsFocused { get; private set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public ICollection<MenuItem<T>> Items => this.items;

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>
        /// The index of the selected.
        /// </value>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        public MenuItem<T> SelectedItem => this.items[this.SelectedIndex];

        /// <summary>
        /// Gets or sets the background color of the current selected item.
        /// </summary>
        /// <value>
        /// The background color of the current selected item.
        /// </value>
        public ConsoleColor SelectionBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the current selected item.
        /// </summary>
        /// <value>
        /// The foreground color of the current selected item.
        /// </value>
        public ConsoleColor SelectionForegroundColor { get; set; }

        /// <summary>
        /// Gets a collection of <see cref="ConsoleKey"/>s that can be used to scroll upward in the menu.
        /// </summary>
        /// <value>
        /// A collection of <see cref="ConsoleKey"/>s that can be used to scroll upward in the menu.
        /// </value>
        public ICollection<ConsoleKey> UpKeys { get; private set; }

        /// <summary>
        /// Defocuses the control and stopps it's behaviour.
        /// </summary>
        public void Defocus()
        {
            this.IsFocused = false;
        }

        /// <summary>
        /// Focuses the control and executes it's behaviour (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        public void Focus()
        {
            this.IsFocused = true;
            this.IsVisible = true;
            this.ScanInput();
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        protected override void Draw(GraphicBuffer buffer)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                buffer.ForegroundDrawingColor = this.ForegroundColor;
                buffer.BackgroundDrawingColor = this.BackgroundColor;

                if (this.SelectedIndex == i)
                {
                    buffer.ForegroundDrawingColor = this.SelectionForegroundColor;
                    buffer.BackgroundDrawingColor = this.SelectionBackgroundColor;
                }

                string bulletString = this.DisplayBullets ? this.Bullet + " " : string.Empty;

                buffer.DrawLine(bulletString + this.items[i].Name, new Coordinate(0, i));

                buffer.ResetColor();
            }
        }

        /// <summary>
        /// Raises the <see cref="ItemChosen"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MenuEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnItemChosen(MenuEventArgs<T> e)
        {
            this.ItemChosen?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="SelectionChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MenuEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnSelectionChanged(MenuEventArgs<T> e)
        {
            this.SelectionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Scans the input (after the item got focused).
        /// </summary>
        protected virtual void ScanInput()
        {
            ConsoleKey pressedKey;

            do
            {
                pressedKey = Console.ReadKey(true).Key;

                if (this.UpKeys.Contains(pressedKey) && this.SelectedIndex > 0)
                {
                    this.SelectedIndex--;
                    this.OnSelectionChanged(new MenuEventArgs<T>(this.SelectedItem));
                }
                else if (this.DownKeys.Contains(pressedKey) && this.SelectedIndex < this.Items.Count - 1)
                {
                    this.SelectedIndex++;
                    this.OnSelectionChanged(new MenuEventArgs<T>(this.SelectedItem));
                }

                this.Invalidate();
            }
            while (pressedKey != ConsoleKey.Enter && this.IsVisible);

            this.Defocus();

            this.OnItemChosen(new MenuEventArgs<T>(this.SelectedItem));
        }
    }
}
