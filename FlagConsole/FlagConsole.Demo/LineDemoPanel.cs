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
        #region Fields

        private readonly Label genericLineLabel;

        private readonly Label horizontalLineLabel;

        private readonly Label verticalLineLabel;

        #endregion

        #region Constructors and Destructors

        public LineDemoPanel()
        {
            this.horizontalLineLabel = new Label { Text = "This is a horizontal line." };
            this.horizontalLineLabel.Size = new Size(this.horizontalLineLabel.Text.Length, 1);
            this.Controls.Add(this.horizontalLineLabel);

            this.verticalLineLabel = new Label { Text = "This is a vertical line." };
            this.verticalLineLabel.Size = new Size(this.verticalLineLabel.Text.Length, 1);
            this.verticalLineLabel.RelativeLocation = new Coordinate(0, 4);
            this.Controls.Add(this.verticalLineLabel);

            this.genericLineLabel = new Label { Text = "This is a generic line." };
            this.genericLineLabel.Size = new Size(this.genericLineLabel.Text.Length, 1);
            this.genericLineLabel.RelativeLocation = new Coordinate(0, 17);
            this.Controls.Add(this.genericLineLabel);
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
