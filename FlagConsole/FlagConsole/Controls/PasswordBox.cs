using System;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a TextBox control, where the user can type passwords.
    /// </summary>
    public class PasswordBox : TextBox
    {
        public PasswordBox()
        {
            Password = string.Empty;
            TextChanged += OnTextChanged;
        }

        /// <summary>
        /// Gets the current password of the <see cref="PasswordBox"/>.
        /// </summary>
        /// <value>
        /// The current password of the <see cref="PasswordBox"/>.
        /// </value>
        public string Password { get; private set; }

        /// <summary>
        /// Replace the entered character in the <see cref="PasswordBox"/> if any with * and save in Password property.
        /// If character is deleted from the <see cref="PasswordBox"/> the character is deleted from the Password property.
        /// </summary>
        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            if(Text.Length > Password.Length)
            {
                var lastChar = Text[Text.Length - 1];
                Password += lastChar;
                Text = Text.Replace(lastChar, '*');
            }
            else if(Text.Length < Password.Length)
            {
                Password = Password.Remove(Password.Length - 1);
            }
        }
    }
}