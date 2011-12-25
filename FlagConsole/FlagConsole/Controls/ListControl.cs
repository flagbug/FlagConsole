namespace FlagConsole.Controls
{
    /// <summary>
    /// Represents a control that displays a list of items (like a Menu or a ListView)
    /// </summary>
    public abstract class ListControl : Control
    {
        /// <summary>
        /// Gets or sets the bullet that is prepended before each item.
        /// </summary>
        /// <value>
        /// The bullet that is prepended before each item..
        /// </value>
        public char Bullet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the bullets should be displayed.
        /// </summary>
        /// <value>
        /// true if the bullets should be displayed; otherwise, false.
        /// </value>
        public bool DisplayBullets { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListControl"/> class.
        /// </summary>
        protected ListControl()
        {
            this.DisplayBullets = true;
        }
    }
}