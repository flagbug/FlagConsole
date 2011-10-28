using System;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Top container, equals the <see cref="System.Windows.Forms.Form"/> class. <para />
    /// Every control and container should be placed here
    /// </summary>
    public class Screen : Container
    {
        /// <summary>
        /// Gets the absolute position to the console.
        /// </summary>
        public override Coordinate AbsoluteLocation
        {
            get { return this.RelativeLocation; }
        }

        /// <summary>
        /// Gets the top conainer (the screen).
        /// </summary>
        public override Container Top
        {
            get { return this; }
        }

        /// <summary>
        /// Updates the container and it's child controls if their visiblity is set to true.
        /// </summary>
        public override void Update(GraphicBuffer buffer)
        {
            base.Update(buffer);

            if (this.IsVisible)
            {
                foreach (Control control in this.Controls)
                {
                    var localBuffer = new GraphicBuffer(control.Size);

                    control.Update(localBuffer);

                    buffer.Merge(localBuffer, control.RelativeLocation);
                }
            }

            buffer.DrawToScreen(this.AbsoluteLocation);
        }

        /// <summary>
        /// Raises the <see cref="Control.Invalidated"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnInvalidated(EventArgs e)
        {
            base.OnInvalidated(e);

            this.Update(new GraphicBuffer(this.Size));
        }
    }
}