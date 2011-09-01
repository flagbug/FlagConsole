using System;
using System.Collections.Generic;
using FlagLib.Collections;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Base class for all containers
    /// </summary>
    public abstract class Container : Control
    {
        private EventCollection<Control> controls = new EventCollection<Control>();

        /// <summary>
        /// Gets the underlying controls.
        /// </summary>
        /// <value>The underlying controls.</value>
        public ICollection<Control> Controls
        {
            get { return this.controls; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        protected Container()
        {
            this.controls.ItemAdded += new EventHandler<EventCollectionEventArgs<Control>>(controls_ItemAdded);
            this.controls.ItemRemoved += new EventHandler<EventCollectionEventArgs<Control>>(controls_ItemRemoved);
            this.controls.ListClearing += new EventHandler(controls_BeforeListCleared);
        }

        /// <summary>
        /// Updates the container and it's child controls if visible is set to true.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (this.IsVisible)
            {
                foreach (Control control in this.controls)
                {
                    control.Update();
                }
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            //Container usually have nothing to draw
        }

        /// <summary>
        /// Handles the BeforeListCleared event of the controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void controls_BeforeListCleared(object sender, EventArgs e)
        {
            foreach (Control control in this.controls)
            {
                control.Parent = null;
            }
        }

        /// <summary>
        /// Handles the ItemRemoved event of the controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FlagLib.Collections.EventCollectionEventArgs&lt;FlagLib.Console.Controls.Control&gt;"/> instance containing the event data.</param>
        private void controls_ItemRemoved(object sender, EventCollectionEventArgs<Control> e)
        {
            e.Item.Parent = null;
        }

        /// <summary>
        /// Handles the ItemAdded event of the controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FlagLib.Collections.EventCollectionEventArgs&lt;FlagLib.Console.Controls.Control&gt;"/> instance containing the event data.</param>
        private void controls_ItemAdded(object sender, EventCollectionEventArgs<Control> e)
        {
            e.Item.Parent = this;
        }
    }
}