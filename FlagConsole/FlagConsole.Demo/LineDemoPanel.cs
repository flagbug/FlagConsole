// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineDemoPanel.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the LineDemoPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Demo
{
    using FlagConsole.Controls;
    using FlagConsole.Drawing;

    internal class LineDemoPanel : Panel
    {
        #region Constructors and Destructors

        public LineDemoPanel()
        {
            var horizontalLineLabel = new Label { Text = "This is a horizontal line." };
            horizontalLineLabel.Size = new Size(horizontalLineLabel.Text.Length, 1);
            this.Controls.Add(horizontalLineLabel);

            var verticalLineLabel = new Label { Text = "This is a vertical line." };
            verticalLineLabel.Size = new Size(verticalLineLabel.Text.Length, 1);
            verticalLineLabel.RelativeLocation = new Coordinate(0, 4);
            this.Controls.Add(verticalLineLabel);

            var genericLineLabel = new Label { Text = "This is a generic line." };
            genericLineLabel.Size = new Size(genericLineLabel.Text.Length, 1);
            genericLineLabel.RelativeLocation = new Coordinate(0, 17);
            this.Controls.Add(genericLineLabel);
        }

        #endregion

        protected override void Draw(GraphicBuffer buffer)
        {
            base.Draw(buffer);

            buffer.DrawLine('#', new Coordinate(0, 2), new Coordinate(15, 2));
            buffer.DrawLine('#', new Coordinate(0, 6), new Coordinate(0, 15));
            buffer.DrawLine('#', new Coordinate(0, 19), new Coordinate(13, 36));
        }
    }
}
