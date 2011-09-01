using FlagConsole.Controls;
using FlagConsole.Measure;

namespace FlagLib.ConsoleTests
{
    internal class LabelPresentationPanel : Panel
    {
        private Label label;

        public LabelPresentationPanel()
        {
            this.label = new Label();
            this.label.Size = new Size(15, 10);
            this.label.Text = "This is a label. As you can see, it arranges the words in a rectangle, which is as big as the label itself.";

            this.Controls.Add(this.label);
        }
    }
}