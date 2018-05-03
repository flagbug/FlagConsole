// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Screen.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Top container, equals the <see cref="System.Windows.Forms.Form" /> class. <para />
//   Every control and container should be placed here
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    using System;

    using FlagConsole.Drawing;

    /// <inheritdoc />
    /// <summary>
    /// Top container, equals the <see cref="!:System.Windows.Forms.Form" /> class. <para />
    /// Every control and container should be placed here
    /// </summary>
    public class Screen : Container
    {
        #region Fields

        private readonly Screen parent;

        #endregion

        #region Constructors and Destructors

        public Screen()
        {
        }

        public Screen(Screen parent)
                : this()
        {
            this.parent = parent;
        }

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Gets the absolute position to the console.
        /// </summary>
        public override Coordinate AbsoluteLocation => this.RelativeLocation;

        /// <inheritdoc />
        /// <summary>
        /// Gets the top container (the screen).
        /// </summary>
        public override Container Top => this;

        public virtual void Activate()
        {
            this.parent?.Deactivate();
            this.Show();
            this.Update(new GraphicBuffer(this.Size));
        }

        public virtual void Deactivate()
        {
            this.Hide();
            this.parent?.Activate();
        }

        public override void Hide()
        {
            base.Hide();
            this.parent?.Show();
        }

        public override void Show()
        {
            this.parent?.Hide();
            base.Show();
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the control if <see cref="Control.IsVisible"/> is set to true.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        public override void Update(GraphicBuffer buffer)
        {
            base.Update(buffer);

            buffer.DrawToScreen(this.AbsoluteLocation);
        }

        /// <inheritdoc />
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
