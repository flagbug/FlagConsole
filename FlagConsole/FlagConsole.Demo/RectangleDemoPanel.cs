using FlagConsole.Controls;
using FlagConsole.Drawing;
using FlagConsole.Measure;

namespace FlagConsole.Demo
{
    internal class RectangleDemoPanel : Panel
    {
        private Label filledRectangleLabel;
        private Label emptyRectangleLabel;

        public RectangleDemoPanel()
        {
            this.filledRectangleLabel = new Label();
            this.filledRectangleLabel.Text = "This is a filled rectangle";
            this.filledRectangleLabel.Size = new Size(this.filledRectangleLabel.Text.Length, 1);
            this.filledRectangleLabel.RelativeLocation = new Point(17, 0);
            this.Controls.Add(this.filledRectangleLabel);

            this.emptyRectangleLabel = new Label();
            this.emptyRectangleLabel.Text = "This is an empty rectangle";
            this.emptyRectangleLabel.Size = new Size(this.emptyRectangleLabel.Text.Length, 1);
            this.emptyRectangleLabel.RelativeLocation = new Point(17, 11);
            this.Controls.Add(this.emptyRectangleLabel);
        }

        protected override void Draw()
        {
            base.Draw();

            Rectangle filledRectangle = new Rectangle(this.AbsoluteLocation, new Size(15, 10), '#', true);
            Rectangle emptyRectangle = new Rectangle(this.AbsoluteLocation + new Point(0, 11), new Size(15, 10), '#', false);

            filledRectangle.Draw();
            emptyRectangle.Draw();
        }
    }
}