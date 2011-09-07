using FlagConsole.Controls;
using FlagConsole.Drawing;

namespace FlagConsole.Demo
{
    internal class LabelDemoPanel : Panel
    {
        private Label label;

        public LabelDemoPanel()
        {
            this.label = new Label();
            this.label.Size = new Size(14, 10);
            this.label.Text = "This is a label. As you can see, it arranges the words in a rectangle, which has the size of the label, in this case 15 x 10.";

            this.Controls.Add(this.label);
        }
    }
}