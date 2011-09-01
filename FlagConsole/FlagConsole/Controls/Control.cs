using FlagConsole.Measure;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Base class for all controls
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// Gets or sets the parent control.
        /// </summary>
        /// <value>
        /// The parent control.
        /// </value>
        public virtual Control Parent { get; set; }

        /// <summary>
        /// Gets the top control (the screen).
        /// </summary>
        /// <value>
        /// The top control.
        /// </value>
        public virtual Control Top
        {
            get { return this.Parent.Top; }
        }

        /// <summary>
        /// Gets or sets the relative location to the parent container.
        /// </summary>
        /// <value>
        /// The relative location to the parent container.
        /// </value>
        public virtual Point RelativeLocation { get; set; }

        /// <summary>
        /// Gets the absolute location in the console.
        /// </summary>
        /// <value>
        /// The absolute location in the console.
        /// </value>
        public virtual Point AbsoluteLocation
        {
            get
            {
                return new Point(
                    this.RelativeLocation.X + this.Parent.AbsoluteLocation.X,
                    this.RelativeLocation.Y + this.Parent.AbsoluteLocation.Y);
            }
        }

        /// <summary>
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>
        /// The size of the control.
        /// </value>
        public virtual Size Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsVisible { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        public Control()
        {
            this.IsVisible = true;
            this.RelativeLocation = new Point();
            this.Size = new Size();
        }

        /// <summary>
        /// Updates the control if it's visibility is set to true.
        /// </summary>
        public virtual void Update()
        {
            this.Clear();

            if (this.IsVisible)
            {
                this.Draw();
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected abstract void Draw();

        /// <summary>
        /// Clears the control's area.
        /// </summary>
        protected virtual void Clear()
        {
            FlagConsole.Drawing.Rectangle eraseArea = new FlagConsole.Drawing.Rectangle(this.AbsoluteLocation, this.Size, ' ', true);
            eraseArea.Draw();
        }
    }
}