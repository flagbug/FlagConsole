// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PasswordBox.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Provides a TextBox control, where the user can type passwords.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// Provides a TextBox control, where the user can type passwords.
    /// </summary>
    public class PasswordBox : TextBox
    {
        #region Constructors and Destructors

        public PasswordBox()
        {
            this.Password = string.Empty;
            this.PasswordChar = '*';
        }

        #endregion

        /// <summary>
        /// Gets the current password of the <see cref="PasswordBox"/>.
        /// </summary>
        /// <value>
        /// The current password of the <see cref="PasswordBox"/>.
        /// </value>
        public string Password { get; private set; }

        /// <summary>
        /// Gets or sets the masking character for the <see cref="PasswordBox"/>.
        /// </summary>
        /// <value>
        /// A masking character to echo when the user enters text into the <see cref="PasswordBox"/>.
        /// The default value is a star character (*).
        /// </value>
        public char PasswordChar { get; set; }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text.Length > this.Password.Length)
            {
                var lastChar = this.Text[this.Text.Length - 1];
                this.Password += lastChar;
                this.Text = new string(this.PasswordChar, this.Text.Length);
            }
            else if (this.Text.Length < this.Password.Length)
            {
                this.Password = this.Password.Remove(this.Password.Length - 1);
            }

            base.OnTextChanged(e);
        }
    }
}
