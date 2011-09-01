namespace FlagConsole.Controls
{
    /// <summary>
    /// Represents a control that displays a list of items (like a Menu or a ListView)
    /// </summary>
    public abstract class ListControl : Control
    {
        /// <summary>
        /// Gets or sets the bullet.
        /// </summary>
        /// <value>
        /// The bullet.
        /// </value>
        public char Bullet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the bullets shall be displayed.
        /// </summary>
        /// <value>
        /// true if the bullets shall be displayed; otherwise, false.
        /// </value>
        public bool DisplayBullets { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListControl"/> class.
        /// </summary>
        public ListControl()
        {
            this.DisplayBullets = true;
        }
    }
}