﻿using System;
using FlagConsole.Controls;
using FlagConsole.Drawing;

namespace FlagConsole.Demo
{
    internal class TextFieldDemoPanel : Panel
    {
        private readonly Label descriptionLabel;
        private readonly Label textLabel;
        private readonly TextField textField;

        public TextFieldDemoPanel()
        {
            this.descriptionLabel =
                new Label
                    {
                        Text = "Enter some text and press enter. The maximum length is set to 8 characters. Of course, this limit can be increased."
                    };
            this.descriptionLabel.Size = new Size(this.descriptionLabel.Text.Length / 3 + 1, 3);
            this.Controls.Add(this.descriptionLabel);

            this.textField = new TextField { Size = new Size(8, 1), Length = 8, RelativeLocation = new Coordinate(0, 4) };
            this.textField.TextEntered += textField_TextEntered;
            this.Controls.Add(this.textField);

            this.textLabel = new Label { RelativeLocation = new Coordinate(0, 6) };
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