// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelDemoPanel.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the LabelDemoPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Demo
{
    using FlagConsole.Controls;
    using FlagConsole.Drawing;

    internal class LabelDemoPanel : Panel
    {
        #region Constructors and Destructors

        public LabelDemoPanel()
        {
            var label = new Label
                        {
                                Size = new Size(14, 10),
                                Text =
                                        "This is a label. As you can see, it arranges the words in a rectangle, which has the size of the label, in this case 15 x 10."
                        };

            this.Controls.Add(label);
        }

        #endregion
    }
}
