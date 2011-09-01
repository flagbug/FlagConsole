using System;
using System.Collections.Generic;
using FlagConsole.Util;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a text-based menu in the console, where the user can select an item
    /// </summary>
    /// <typeparam name="T">Type of the item that the user can select</typeparam>
    public class Menu<T> : Control
    {
        #region Item
        /// <summary>
        /// An item for selection
        /// </summary>
        public class Item
        {
            private string name;
            /// <summary>
            /// Name of the item, shown in the menu
            /// </summary>
            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            private T value;
            /// <summary>
            /// Value of the item, gets returned when the user selects an item
            /// </summary>
            public T Value
            {
                get
                {
                    return this.value;
                }

                set
                {
                    this.value = value;
                }
            }

            public Item(string name, T value)
            {
                this.name = name;
                this.value = value;
            }
        }
        #endregion

        #region Members
        protected List<Item> items = new List<Item>();
        /// <summary>
        /// List of all options
        /// </summary>
        public List<Item> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }

        protected int selectedIndex = 0;
        /// <summary>
        /// Current selected index of the options
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                this.selectedIndex = value;
            }
        }

        /// <summary>
        /// Current selected item
        /// </summary>
        public Item SelectedItem
        {
            get
            {
                return this.Items[this.selectedIndex];
            }
        }

        protected ConsoleKey upKey = ConsoleKey.UpArrow;
        /// <summary>
        /// Defines the key where the upper item gets selected
        /// </summary>
        public ConsoleKey UpKey
        {
            get
            {
                return this.upKey;
            }

            set
            {
                this.upKey = value;
            }
        }

        protected ConsoleKey downKey = ConsoleKey.DownArrow;
        /// <summary>
        /// Defines the key where the lower item gets selected
        /// </summary>
        public ConsoleKey DownKey
        {
            get
            {
                return this.downKey;
            }

            set
            {
                this.downKey = value;
            }
        }

        protected ConsoleColor foreColor = ConsoleColor.Gray;
        /// <summary>
        /// Foreground color of the none-selected item-text
        /// </summary>
        public ConsoleColor ForeColor
        {
            get
            {
                return this.foreColor;
            }

            set
            {
                this.foreColor = value;
            }
        }

        protected ConsoleColor backColor = ConsoleColor.Black;
        /// <summary>
        /// Backgroudn color of the none-selected item-text
        /// </summary>
        public ConsoleColor BackColor
        {
            get
            {
                return this.backColor;
            }

            set
            {
                this.backColor = value;
            }
        }

        protected ConsoleColor selectionBackColor = ConsoleColor.White;
        /// <summary>
        /// Background color of the selected item-text
        /// </summary>
        public ConsoleColor SelectionBackColor
        {
            get
            {
                return this.selectionBackColor;
            }

            set
            {
                this.selectionBackColor = value;
            }
        }

        protected ConsoleColor selectionForeColor = ConsoleColor.Black;
        /// <summary>
        /// Foregroudn color of the selected item-text
        /// </summary>
        public ConsoleColor SelectionForeColor
        {
            get
            {
                return this.selectionForeColor;
            }

            set
            {
                this.selectionForeColor = value;
            }
        }
        #endregion

        #region Ctor
        public Menu()
        {
            this.AbsolutePosition = new Position();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Activates the menu
        /// </summary>
        public override void Activate()
        {
            if (this.ParentContainer.Activated)
            {
                this.Activated = true;

                this.ScanInput();
                this.OnItemChosen();
            }
        }

        /// <summary>
        /// Deactivates the menu
        /// </summary>
        public override void Deactivate()
        {
            this.Activated = false;
        }

        protected void ScanInput()
        {
            ConsoleKey pressedKey;

            do
            {
                this.Show();

                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == this.UpKey)
                {
                    if (this.SelectedIndex > 0)
                    {
                        this.SelectedIndex--;
                        this.OnSelectionChanged();
                    }
                }

                else if (pressedKey == this.DownKey)
                {
                    if (this.SelectedIndex < this.Items.Count - 1)
                    {
                        this.SelectedIndex++;
                        this.OnSelectionChanged();
                    }
                }
            }
            while (pressedKey != ConsoleKey.Enter && this.Activated);
        }

        protected override void Show()
        {
            Console.BackgroundColor = this.BackColor;

            for(int i = 0; i < this.Items.Count; i++)
            {
                if (this.SelectedIndex == i)
                {
                    Console.ForegroundColor = this.SelectionForeColor;
                    Console.BackgroundColor = this.SelectionBackColor;
                }
                
                Console.SetCursorPosition(this.AbsolutePosition.X, this.AbsolutePosition.Y + i);

                Console.WriteLine(this.Items[i].Name);

                if (this.SelectedIndex == i)
                {
                    Console.ForegroundColor = this.ForeColor;
                    Console.BackgroundColor = this.BackColor;
                }
            }
        }

        protected virtual void OnItemChosen()
        {
            if (this.ItemChosen != null)
            {
                this.ItemChosen.Invoke(this, new ItemChosenEventArgs(this.SelectedItem));
            }
        }

        protected virtual void OnSelectionChanged()
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Invoked when an item gets chosen
        /// </summary>
        public event EventHandler<ItemChosenEventArgs> ItemChosen;
        public event EventHandler SelectionChanged;
        #endregion        
        
        #region EventArgs
        public class ItemChosenEventArgs : EventArgs
        {
            private Item chosenItem;
            public Item ChosenItem
            {
                get
                {
                    return this.chosenItem;
                }
            }

            public ItemChosenEventArgs(Item chosenItem)
            {
                this.chosenItem = chosenItem;
            }
        }
        #endregion
    }
}
