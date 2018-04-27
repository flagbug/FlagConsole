// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectangleDemoPanel.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the RectangleDemoPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Demo
{
    using FlagConsole.Controls;
    using FlagConsole.Drawing;

    internal class RectangleDemoPanel : Panel
    {
        #region Fields

        private readonly Label emptyRectangleLabel;

        private readonly Label filledRectangleLabel;

        #endregion

        #region Constructors and Destructors

        public RectangleDemoPanel()
        {
            this.filledRectangleLabel = new Label { Text = "This is a filled rectangle." };
            this.filledRectangleLabel.Size = new Size(this.filledRectangleLabel.Text.Length, 1);
            this.filledRectangleLabel.RelativeLocation = new Coordinate(17, 0);
            this.Controls.Add(this.filledRectangleLabel);

            this.emptyRectangleLabel = new Label { Text = "This is an empty rectangle." };
            this.emptyRectangleLabel.Size = new Size(this.emptyRectangleLabel.Text.Length, 1);
            this.emptyRectangleLabel.RelativeLocation = new Coordinate(17, 11);
            this.Controls.Add(this.emptyRectangleLabel);
        }

        #endregion

        protected override void Draw(GraphicBuffer buffer)
        {
            base.Draw(buffer);

            buffer.DrawRectangle('#', Coordinate.Origin, new Size(15, 10), true);
            buffer.DrawRectangle('#', new Coordinate(0, 11), new Size(15, 10), false);
        }
    }
}
