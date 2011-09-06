using FlagConsole.Controls;
using FlagConsole.Drawing;
using FlagConsole.Measure;

namespace FlagConsole.Demo
{
    internal class LineDemoPanel : Panel
    {
        private Label horizontalLineLabel;
        private Label verticalLineLabel;
        private Label genericLineLabel;

        public LineDemoPanel()
        {
            this.horizontalLineLabel = new Label();
            this.horizontalLineLabel.Text = "This is a horizontal line.";
            this.horizontalLineLabel.Size = new Size(this.horizontalLineLabel.Text.Length, 1);
            this.Controls.Add(this.horizontalLineLabel);

            this.verticalLineLabel = new Label();
            this.verticalLineLabel.Text = "This is a vertical line.";
            this.verticalLineLabel.Size = new Size(this.verticalLineLabel.Text.Length, 1);
            this.verticalLineLabel.RelativeLocation = new Coordinate(0, 4);
            this.Controls.Add(this.verticalLineLabel);

            this.genericLineLabel = new Label();
            this.genericLineLabel.Text = "This is a generic line.";
            this.genericLineLabel.Size = new Size(this.genericLineLabel.Text.Length, 1);
            this.genericLineLabel.RelativeLocation = new Coordinate(0, 17);
            this.Controls.Add(this.genericLineLabel);
        }

        protected override void Draw(GraphicBuffer buffer)
        {
            base.Draw(buffer);
            /*
            Line horizontalLine = new Line(this.AbsoluteLocation + new Coordinate(0, 2), this.AbsoluteLocation + new Coordinate(15, 2), '#');
            Line verticalLine = new Line(this.AbsoluteLocation + new Coordinate(0, 6), this.AbsoluteLocation + new Coordinate(0, 15), '#');
            Line genericLine = new Line(this.AbsoluteLocation + new Coordinate(0, 19), this.AbsoluteLocation + new Coordinate(13, 36), '#');

            horizontalLine.Draw();
            verticalLine.Draw();
            genericLine.Draw();*/
        }
    }
}