using FlagConsole.Controls;
using FlagConsole.Measure;

namespace FlagConsole.Demo
{
    internal class ListViewDemoPanel : Panel
    {
        private ListView<string> listView;
        private ListView<string> listView2;

        public ListViewDemoPanel()
        {
            this.listView = new ListView<string>();
            this.listView.Size = new Size(14, 8);
            this.listView.Items.Add("This");
            this.listView.Items.Add("is a");
            this.listView.Items.Add("list view.");
            this.listView.Items.Add("It displays");
            this.listView.Items.Add("the items");
            this.listView.Items.Add("like a menu,");
            this.listView.Items.Add("but cannot");
            this.listView.Items.Add("be selected.");

            this.Controls.Add(this.listView);

            this.listView2 = new ListView<string>();
            this.listView2.RelativeLocation = new Coordinate(18, 0);
            this.listView2.Size = new Size(14, 8);
            this.listView2.Bullet = '-';
            this.listView2.Items.Add("This");
            this.listView2.Items.Add("list view");
            this.listView2.Items.Add("has a other");
            this.listView2.Items.Add("bullet type");
            this.listView2.Items.Add("than the");
            this.listView2.Items.Add("list view");
            this.listView2.Items.Add("to the left.");

            this.Controls.Add(this.listView2);
        }
    }
}