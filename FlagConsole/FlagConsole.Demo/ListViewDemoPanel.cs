using FlagConsole.Controls;
using FlagConsole.Measure;

namespace FlagConsole.Demo
{
    internal class ListViewDemoPanel : Panel
    {
        private ListView<string> listView;

        public ListViewDemoPanel()
        {
            this.listView = new ListView<string>();
            this.listView.Size = new Size(5, 3);
            this.listView.Items.Add("This");
            this.listView.Items.Add("is a");
            this.listView.Items.Add("list view.");
            this.listView.Items.Add("It displays");
            this.listView.Items.Add("the items");
            this.listView.Items.Add("like a menu,");
            this.listView.Items.Add("but cannot");
            this.listView.Items.Add("be selected.");

            this.Controls.Add(this.listView);
        }
    }
}