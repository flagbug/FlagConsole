using FlagConsole.Controls;
using FlagConsole.Drawing;

namespace FlagConsole.Demo
{
    internal class EllipseDemoPanel : Panel
    {
        private readonly Label ellipseLabel;
        private readonly Label circleLabel;

        public EllipseDemoPanel()
        {
            this.ellipseLabel = new Label { Text = "This is an ellipse." };
            this.ellipseLabel.Size = new Size(this.ellipseLabel.Text.Length, 1);
            this.ellipseLabel.RelativeLocation = new Coordinate(17, 0);
            this.Controls.Add(this.ellipseLabel);

            this.circleLabel = new Label { Text = "This is a circle." };
            this.circleLabel.Size = new Size(this.circleLabel.Text.Length, 1);
            this.circleLabel.RelativeLocation = new Coordinate(19, 18);
            this.Controls.Add(this.circleLabel);
        }

        protected override void Draw(GraphicBuffer buffer)
        {
            base.Draw(buffer);

            buffer.DrawEllipse('#', new Coordinate(11, 7), 4, 7);
            buffer.DrawEllipse('#', new Coordinate(11, 25), 7, 7);
        }
    }
}