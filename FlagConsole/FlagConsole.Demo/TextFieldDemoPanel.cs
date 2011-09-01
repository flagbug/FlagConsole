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
            this.descriptionLabel.Text = "Enter some text and press enter. The maximum length is set to 8 characters";
            this.descriptionLabel.Size = new Size(this.descriptionLabel.Text.Length / 2 + 1, 2);
            this.Controls.Add(this.descriptionLabel);

            this.textField = new TextField();
            this.textField.Length = 8;
            this.textField.RelativeLocation = new Point(0, 3);
            this.textField.TextEntered += new System.EventHandler(textField_TextEntered);
            this.Controls.Add(this.textField);

            this.textLabel = new Label();
            this.textLabel.RelativeLocation = new Point(0, 5);
            this.Controls.Add(this.textLabel);
        }

        private void textField_TextEntered(object sender, EventArgs e)
        {
            this.textLabel.Text = "You have entered: " + this.textField.Text;
            this.textLabel.Size = new Size(this.textLabel.Text.Length, 1);
            this.Update();
        }

        public void Activate()
        {
            this.textField.Focus();
        }
    }
}