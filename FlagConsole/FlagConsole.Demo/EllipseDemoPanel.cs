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
        #region Constructors and Destructors

        public EllipseDemoPanel()
        {
            var ellipseLabel = new Label { Text = "This is an ellipse." };
            ellipseLabel.Size = new Size(ellipseLabel.Text.Length, 1);
            ellipseLabel.RelativeLocation = new Coordinate(17, 0);
            this.Controls.Add(ellipseLabel);

            var circleLabel = new Label { Text = "This is a circle." };
            circleLabel.Size = new Size(circleLabel.Text.Length, 1);
            circleLabel.RelativeLocation = new Coordinate(19, 18);
            this.Controls.Add(circleLabel);
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
