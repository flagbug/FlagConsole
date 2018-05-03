// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewDemoPanel.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewDemoPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Demo
{
    using FlagConsole.Controls;
    using FlagConsole.Drawing;

    internal class ListViewDemoPanel : Panel
    {
        #region Constructors and Destructors

        public ListViewDemoPanel()
        {
            var listView = new ListView<string> { Size = new Size(14, 8) };
            listView.Items.Add("This");
            listView.Items.Add("is a");
            listView.Items.Add("list view.");
            listView.Items.Add("It displays");
            listView.Items.Add("the items");
            listView.Items.Add("like a menu,");
            listView.Items.Add("but cannot");
            listView.Items.Add("be selected.");

            this.Controls.Add(listView);

            var listView2 = new ListView<string>
                            {
                                    RelativeLocation = new Coordinate(18, 0),
                                    Size = new Size(14, 8),
                                    Bullet = '-'
                            };
            listView2.Items.Add("This");
            listView2.Items.Add("list view");
            listView2.Items.Add("has a other");
            listView2.Items.Add("bullet type");
            listView2.Items.Add("than the");
            listView2.Items.Add("list view");
            listView2.Items.Add("to the left.");

            this.Controls.Add(listView2);
        }

        #endregion
    }
}
