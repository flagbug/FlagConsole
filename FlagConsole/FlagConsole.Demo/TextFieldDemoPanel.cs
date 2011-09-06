using System;
using FlagConsole.Controls;
using FlagConsole.Measure;

namespace FlagConsole.Demo
{
    internal class TextFieldDemoPanel : Panel
    {
        private Label descriptionLabel;
        private Label textLabel;
        private TextField textField;

        public TextFieldDemoPanel()
        {
            this.descriptionLabel = new Label();
            this.descriptionLabel.Text = "Enter some text and press enter. The maximum length is set to 8 characters. Of course, this limit can be increased.";
            this.descriptionLabel.Size = new Size(this.descriptionLabel.Text.Length / 3 + 1, 3);
            this.Controls.Add(this.descriptionLabel);

            this.textField = new TextField();
            this.textField.Size = new Size(8, 1);
            this.textField.Length = 8;
            this.textField.RelativeLocation = new Coordinate(0, 4);
            this.textField.TextEntered += new System.EventHandler(textField_TextEntered);
            this.Controls.Add(this.textField);

            this.textLabel = new Label();
            this.textLabel.RelativeLocation = new Coordinate(0, 6);
            this.Controls.Add(this.textLabel);
        }

        private void textField_TextEntered(object sender, EventArgs e)
        {
            this.textLabel.Text = "You have entered: " + this.textField.Text;
            this.textLabel.Size = new Size(this.textLabel.Text.Length, 1);

            this.OnInvalidated(EventArgs.Empty);
        }

        public void Activate()
        {
            this.textField.Focus();
        }
    }
}