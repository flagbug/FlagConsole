using System;
using System.Collections.Generic;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a text-based menu in the console, where the user can select an item
    /// </summary>
    /// <typeparam name="T">Type of the item that the user can select</typeparam>
    public class Menu<T> : ListControl, IFocusable
    {
        private readonly List<MenuItem<T>> items;

        /// <summary>
        /// Gets the items.
        /// </summary>
        public ICollection<MenuItem<T>> Items
        {
            get { return this.items; }
        }

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
        public MenuItem<T> SelectedItem
        {
            get
            {
                return this.items[this.SelectedIndex];
            }
        }

        /// <summary>
        /// Gets the up keys.
        /// </summary>
        /// <value>
        /// Up key.
        /// </value>
        public ICollection<ConsoleKey> UpKeys { get; private set; }

        /// <summary>
        /// Gets the down keys.
        /// </summary>
        /// <value>
        /// Down key.
        /// </value>
        public ICollection<ConsoleKey> DownKeys { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IFocusable"/> is focused.
        /// </summary>
        /// <value>
        /// true if focused; otherwise, false.
        /// </value>
        public virtual bool IsFocused { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the selection.
        /// </summary>
        /// <value>
        /// The foreground color of the selection.
        /// </value>
        public ConsoleColor SelectionForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the selection.
        /// </summary>
        /// <value>
        /// The background color of the selection.
        /// </value>
        public ConsoleColor SelectionBackgroundColor { get; set; }

        /// <summary>
        /// Occurs when a item has been chosen.
        /// </summary>
        public event EventHandler<MenuEventArgs<T>> ItemChosen;

        /// <summary>
        /// Occurs when the selection has been changed.
        /// </summary>
        public event EventHandler<MenuEventArgs<T>> SelectionChanged;

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

        /// <summary>
        /// Draws the control.
        /// </summary>
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

                string bulletString = this.DisplayBullets ? this.Bullet + " " : String.Empty;

                buffer.DrawLine(bulletString + this.items[i].Name, new Coordinate(0, i));

                buffer.ResetColor();
            }
        }

        /// <summary>
        /// Focuses the control and executes it's behaviour (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        public virtual void Focus()
        {
            this.IsFocused = true;
            this.IsVisible = true;
            this.ScanInput();
        }

        /// <summary>
        /// Defocuses the control and stopps it's behaviour.
        /// </summary>
        public virtual void Defocus()
        {
            this.IsFocused = false;
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

                this.OnInvalidated(EventArgs.Empty);
            }
            while (pressedKey != ConsoleKey.Enter && this.IsVisible);

            this.OnItemChosen(new MenuEventArgs<T>(this.SelectedItem));
        }

        /// <summary>
        /// Raises the <see cref="ItemChosen"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MenuEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnItemChosen(MenuEventArgs<T> e)
        {
            if (this.ItemChosen != null)
            {
                this.ItemChosen.Invoke(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="SelectionChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MenuEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnSelectionChanged(MenuEventArgs<T> e)
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged.Invoke(this, e);
            }
        }
    }
}