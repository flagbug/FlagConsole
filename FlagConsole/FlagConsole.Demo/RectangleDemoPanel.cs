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
        #region Constructors and Destructors

        public RectangleDemoPanel()
        {
            var filledRectangleLabel = new Label { Text = "This is a filled rectangle." };
            filledRectangleLabel.Size = new Size(filledRectangleLabel.Text.Length, 1);
            filledRectangleLabel.RelativeLocation = new Coordinate(17, 0);
            this.Controls.Add(filledRectangleLabel);

            var emptyRectangleLabel = new Label { Text = "This is an empty rectangle." };
            emptyRectangleLabel.Size = new Size(emptyRectangleLabel.Text.Length, 1);
            emptyRectangleLabel.RelativeLocation = new Coordinate(17, 11);
            this.Controls.Add(emptyRectangleLabel);
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
