namespace FlagConsole.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using FlagConsole.Drawing;

    /// <summary>
    /// Base class for all containers
    /// </summary>
    public abstract class Container : Control
    {
        private readonly ObservableCollection<Control> controls;

        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        protected Container()
        {
            this.controls = new ObservableCollection<Control>();
            this.controls.CollectionChanged += this.controls_CollectionChanged;
        }

        /// <summary>
        /// Gets the underlying controls.
        /// </summary>
        /// <value>
        /// The underlying controls.
        /// </value>
        public ICollection<Control> Controls => this.controls;

        /// <summary>
        /// Updates the control if <see cref="Control.IsVisible"/> is set to true.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        public override void Update(GraphicBuffer buffer)
        {
            base.Update(buffer);

            if (this.IsVisible)
            {
                foreach (Control control in this.controls)
                {
                    var localBuffer = new GraphicBuffer(control.Size);

                    control.Update(localBuffer);

                    buffer.Merge(localBuffer, control.RelativeLocation);
                }
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw(GraphicBuffer buffer)
        {
            buffer.BackgroundDrawingColor = this.BackgroundColor;
            buffer.ForegroundDrawingColor = this.ForegroundColor;

            buffer.DrawRectangle(' ', Coordinate.Origin, this.Size, true);
        }

        /// <summary>
        /// Handles the Invalidated event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void control_Invalidated(object sender, EventArgs e)
        {
            this.OnInvalidated(EventArgs.Empty);
        }

        /// <summary>
        /// Handles the CollectionChanged event of the controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void controls_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Control control in e.NewItems)
                    {
                        control.Parent = this;
                        control.Invalidated += this.control_Invalidated;

                        this.OnInvalidated(EventArgs.Empty);
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Control control in e.OldItems)
                    {
                        control.Parent = null;
                        control.Invalidated -= this.control_Invalidated;

                        this.OnInvalidated(EventArgs.Empty);
                    }

                    break;
            }
        }
    }
}
