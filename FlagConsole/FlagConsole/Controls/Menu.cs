using System;
using System.Collections.Generic;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a text-based menu in the console, where the user can select an item
    /// </summary>
    /// <typeparam name="T">Type of the item that the user can select</typeparam>
    public class Menu<T> : Control, IFocusable
    {
        private List<MenuItem<T>> items;

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public ICollection<MenuItem<T>> Items
        {
            get { return this.items; }
        }

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
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
        /// <value>Up key.</value>
        public ICollection<ConsoleKey> UpKeys { get; private set; }

        /// <summary>
        /// Gets the down keys.
        /// </summary>
        /// <value>Down key.</value>
        public ICollection<ConsoleKey> DownKeys { get; private set; }

        /// <summary>
        /// Gets or sets the color of the foreground.
        /// </summary>
        /// <value>The color of the foreground.</value>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the selection background.
        /// </summary>
        /// <value>The color of the selection background.</value>
        public ConsoleColor SelectionBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the selection foreground.
        /// </summary>
        /// <value>The color of the selection foreground.</value>
        public ConsoleColor SelectionForegroundColor { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IFocusable"/> is focused.
        /// </summary>
        /// <value>true if focused; otherwise, false.</value>
        public virtual bool IsFocused { get; set; }

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
            this.UpKeys = new List<ConsoleKey> { ConsoleKey.UpArrow };
            this.DownKeys = new List<ConsoleKey> { ConsoleKey.DownArrow };
            this.ForegroundColor = ConsoleColor.Gray;
            this.BackgroundColor = ConsoleColor.Black;
            this.SelectionBackgroundColor = ConsoleColor.White;
            this.SelectionForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            System.Console.BackgroundColor = this.BackgroundColor;

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.SelectedIndex == i)
                {
                    System.Console.ForegroundColor = this.SelectionForegroundColor;
                    System.Console.BackgroundColor = this.SelectionBackgroundColor;
                }

                System.Console.SetCursorPosition(this.AbsoluteLocation.X, this.AbsoluteLocation.Y + i);

                System.Console.WriteLine(this.items[i].Name);

                if (this.SelectedIndex == i)
                {
                    System.Console.ForegroundColor = this.ForegroundColor;
                    System.Console.BackgroundColor = this.BackgroundColor;
                }
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
                this.Update();

                pressedKey = System.Console.ReadKey(true).Key;

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
            }
            while (pressedKey != ConsoleKey.Enter && this.IsVisible);

            this.OnItemChosen(new MenuEventArgs<T>(this.SelectedItem));
        }

        /// <summary>
        /// Raises the <see cref="E:ItemChosen"/> event.
        /// </summary>
        /// <param name="e">The <see cref="FlagConsole.Console.Controls.MenuEventArgs&lt;T&gt;"/> instance containing the event data.</param>
        protected virtual void OnItemChosen(MenuEventArgs<T> e)
        {
            if (this.ItemChosen != null)
            {
                this.ItemChosen.Invoke(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:SelectionChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="FlagConsole.Console.Controls.MenuEventArgs&lt;T&gt;"/> instance containing the event data.</param>
        protected virtual void OnSelectionChanged(MenuEventArgs<T> e)
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged.Invoke(this, e);
            }
        }
    }
}