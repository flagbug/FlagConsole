using FlagConsole.Drawing;
using FlagConsole.Measure;

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
        /// <value>
        /// The absolute position to the console.
        /// </value>
        public override Coordinate AbsoluteLocation
        {
            get { return this.RelativeLocation; }
        }

        /// <summary>
        /// Gets the top conainer (the screen).
        /// </summary>
        /// <value>
        /// The top conainer.
        /// </value>
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
                    GraphicBuffer localBuffer = new GraphicBuffer(control.Size);

                    control.Update(localBuffer);

                    buffer.Merge(localBuffer, control.RelativeLocation);
                }
            }

            buffer.DrawToScreen(this.AbsoluteLocation);
        }

        protected override void OnInvalidated(System.EventArgs e)
        {
            base.OnInvalidated(e);

            this.Update(new GraphicBuffer(this.Size));
        }
    }
}