using System;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Base class for all controls
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// Gets or sets the parent container.
        /// </summary>
        /// <value>
        /// The parent container.
        /// </value>
        public Container Parent { get; set; }

        /// <summary>
        /// Gets the top container.
        /// </summary>
        public virtual Container Top
        {
            get { return this.Parent.Top; }
        }

        /// <summary>
        /// Gets or sets the relative location to the parent container.
        /// </summary>
        /// <value>
        /// The relative location to the parent container.
        /// </value>
        public Coordinate RelativeLocation { get; set; }

        /// <summary>
        /// Gets the absolute location in the console.
        /// </summary>
        public virtual Coordinate AbsoluteLocation
        {
            get { return this.RelativeLocation + this.Parent.AbsoluteLocation; }
        }

        /// <summary>
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>
        /// The size of the control.
        /// </value>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Occurs when the control requires redrawing.
        /// </summary>
        public event EventHandler Invalidated;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        protected Control()
        {
            this.IsVisible = true;
            this.RelativeLocation = Coordinate.Origin;
            this.Size = new Size();
            this.ForegroundColor = Console.ForegroundColor;
            this.BackgroundColor = Console.BackgroundColor;
        }

        /// <summary>
        /// Invalidates the control and causes a redraw.
        /// </summary>
        public void Invalidate()
        {
            this.OnInvalidated(EventArgs.Empty);
        }

        /// <summary>
        /// Updates the control if it's visibility is set to true.
        /// </summary>
        public virtual void Update(GraphicBuffer buffer)
        {
            if (this.IsVisible)
            {
                this.Draw(buffer);
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="buffer">The graphic buffer.</param>
        protected abstract void Draw(GraphicBuffer buffer);

        /// <summary>
        /// Raises the <see cref="Invalidated"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnInvalidated(EventArgs e)
        {
            if (this.Invalidated != null)
            {
                this.Invalidated(this, e);
            }
        }
    }
}