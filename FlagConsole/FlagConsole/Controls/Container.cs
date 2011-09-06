using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using FlagConsole.Drawing;
using FlagConsole.Measure;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Base class for all containers
    /// </summary>
    public abstract class Container : Control
    {
        private ObservableCollection<Control> controls = new ObservableCollection<Control>();

        /// <summary>
        /// Gets the underlying controls.
        /// </summary>
        /// <value>
        /// The underlying controls.
        /// </value>
        public ICollection<Control> Controls
        {
            get { return this.controls; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        protected Container()
        {
            this.controls.CollectionChanged += new NotifyCollectionChangedEventHandler(controls_CollectionChanged);
        }

        /// <summary>
        /// Updates the container and it's child controls if their visiblity is set to true.
        /// </summary>
        public override void Update(GraphicBuffer buffer)
        {
            if (this.IsVisible)
            {
                foreach (Control control in this.controls)
                {
                    GraphicBuffer localBuffer = new GraphicBuffer(control.Size);

                    control.Update(buffer);

                    buffer.Merge(localBuffer, control.RelativeLocation);
                }
            }

            base.Update(buffer);
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw(GraphicBuffer buffer)
        {
            GraphicBuffer local = new GraphicBuffer(this.Size);

            buffer.Merge(local, new Coordinate());
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
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Control control in e.OldItems)
                    {
                        control.Parent = null;
                    }
                    break;
            }
        }
    }
}