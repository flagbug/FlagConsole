// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EllipseDemoPanel.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the EllipseDemoPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Demo
{
    using FlagConsole.Controls;
    using FlagConsole.Drawing;

    internal class EllipseDemoPanel : Panel
    {
        #region Fields

        private readonly Label circleLabel;

        private readonly Label ellipseLabel;

        #endregion

        #region Constructors and Destructors

        public EllipseDemoPanel()
        {
            this.ellipseLabel = new Label { Text = "This is an ellipse." };
            this.ellipseLabel.Size = new Size(this.ellipseLabel.Text.Length, 1);
            this.ellipseLabel.RelativeLocation = new Coordinate(17, 0);
            this.Controls.Add(this.ellipseLabel);

            this.circleLabel = new Label { Text = "This is a circle." };
            this.circleLabel.Size = new Size(this.circleLabel.Text.Length, 1);
            this.circleLabel.RelativeLocation = new Coordinate(19, 18);
            this.Controls.Add(this.circleLabel);
        }

        #endregion

        protected override void Draw(GraphicBuffer buffer)
        {
            base.Draw(buffer);

            buffer.DrawEllipse('#', new Coordinate(11, 7), 4, 7);
            buffer.DrawEllipse('#', new Coordinate(11, 25), 7, 7);
        }
    }
}
