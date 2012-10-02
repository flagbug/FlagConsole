using System;
using FlagConsole.Controls;
using FlagConsole.Drawing;

namespace FlagConsole.Demo
{
    public class PasswordTextBoxDemoPanel : Panel
    {
        private readonly Label _descriptionLabel;
        private readonly Label _textLabel;
        private readonly PasswordTextBox _passwordTextBox;

        public PasswordTextBoxDemoPanel()
        {
            _descriptionLabel = new Label
                { Text = "Enter a password and press enter. The maximum length is set to 5 characters, but it has a width of 8. Of course, this limits can be increased." };
            _descriptionLabel.Size = new Size(_descriptionLabel.Text.Length/3 + 1, 4);
            Controls.Add(_descriptionLabel);

            _passwordTextBox = new PasswordTextBox { Size = new Size(8, 1), MaxLength = 5, RelativeLocation = new Coordinate(0, 4) };
            _passwordTextBox.TextSubmitted += PasswordTextBoxPasswordSubmitted;
            Controls.Add(_passwordTextBox);

            _textLabel = new Label { RelativeLocation = new Coordinate(0, 6) };
            Controls.Add(_textLabel);
        }

        private void PasswordTextBoxPasswordSubmitted(object sender, EventArgs e)
        {
            _textLabel.Text = "You have entered: " + _passwordTextBox.Password;
            _textLabel.Size = new Size(_textLabel.Text.Length, 1);

            OnInvalidated(EventArgs.Empty);
        }

        public void Activate()
        {
            _passwordTextBox.Focus();
        }
    }
}