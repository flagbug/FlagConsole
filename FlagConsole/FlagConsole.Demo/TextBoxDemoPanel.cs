﻿namespace FlagConsole.Demo
{
    using System;

    using FlagConsole.Controls;
    using FlagConsole.Drawing;

    internal class TextBoxDemoPanel : Panel
    {
        private readonly Label descriptionLabel;

        private readonly TextBox textBox;

        private readonly Label textLabel;

        public TextBoxDemoPanel()
        {
            this.descriptionLabel = new Label
                                        {
                                            Text =
                                                "Enter some text and press enter. The maximum length is set to 5 characters, but it has a width of 8. Of course, this limits can be increased."
                                        };
            this.descriptionLabel.Size = new Size(this.descriptionLabel.Text.Length / 3 + 1, 4);
            this.Controls.Add(this.descriptionLabel);

            this.textBox = new TextBox
                               {
                                   Size = new Size(8, 1),
                                   MaxLength = 5,
                                   RelativeLocation = new Coordinate(0, 4)
                               };
            this.textBox.TextSubmitted += this.TextBoxTextSubmitted;
            this.Controls.Add(this.textBox);

            this.textLabel = new Label { RelativeLocation = new Coordinate(0, 6) };
            this.Controls.Add(this.textLabel);
        }

        public void Activate()
        {
            this.textBox.Focus();
        }

        private void TextBoxTextSubmitted(object sender, EventArgs e)
        {
            this.textLabel.Text = "You have entered: " + this.textBox.Text;
            this.textLabel.Size = new Size(this.textLabel.Text.Length, 1);

            this.OnInvalidated(EventArgs.Empty);
        }
    }
}
