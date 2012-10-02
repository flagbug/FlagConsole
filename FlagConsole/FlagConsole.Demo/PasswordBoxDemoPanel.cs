using FlagConsole.Controls;
using FlagConsole.Drawing;
using System;

namespace FlagConsole.Demo
{
    internal class PasswordBoxDemoPanel : Panel
    {
        private readonly Label descriptionLabel;
        private readonly PasswordBox passwordBox;
        private readonly Label textLabel;

        public PasswordBoxDemoPanel()
        {
            this.descriptionLabel =
                new Label
                {
                    Text = "Enter a password and press enter. The maximum length is set to 5 characters, but it has a width of 8. Of course, this limits can be increased."
                };
            this.descriptionLabel.Size = new Size(this.descriptionLabel.Text.Length / 3 + 1, 4);
            this.Controls.Add(this.descriptionLabel);

            this.passwordBox = new PasswordBox { Size = new Size(8, 1), MaxLength = 5, RelativeLocation = new Coordinate(0, 4) };
            this.passwordBox.TextSubmitted += PasswordTextBoxPasswordSubmitted;
            this.Controls.Add(this.passwordBox);

            this.textLabel = new Label { RelativeLocation = new Coordinate(0, 6) };
            this.Controls.Add(this.textLabel);
        }

        public void Activate()
        {
            this.passwordBox.Focus();
        }

        private void PasswordTextBoxPasswordSubmitted(object sender, EventArgs e)
        {
            this.textLabel.Text = "You have entered: " + this.passwordBox.Password;
            this.textLabel.Size = new Size(this.textLabel.Text.Length, 1);

            OnInvalidated(EventArgs.Empty);
        }
    }
}