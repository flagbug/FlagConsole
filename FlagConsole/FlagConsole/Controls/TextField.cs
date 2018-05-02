// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextField.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Provides a text field where the user can do an input
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    using System;

    using FlagConsole.Drawing;

    /// <summary>
    /// Provides a text field where the user can do an input
    /// </summary>
    [Obsolete("This class is obsolete, use TextBox instead.")]
    public class TextField : Control, IFocusable
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextField"/> class.
        /// </summary>
        public TextField()
        {
            this.Text = string.Empty;
            this.BackgroundColor = ConsoleColor.White;
            this.ForegroundColor = ConsoleColor.Black;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the input has been entered.
        /// </summary>
        public event EventHandler TextEntered;

        #endregion

        /// <summary>
        /// Gets a value indicating whether this <see cref="IFocusable"/> is focused.
        /// </summary>
        /// <value>
        /// true if focused; otherwise, false.
        /// </value>
        public virtual bool IsFocused { get; set; }

        /// <summary>
        /// Gets or sets the length of the text field.
        /// </summary>
        /// <value>
        /// The length of the text field.
        /// </value>
        public virtual int Length { get; set; }

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public virtual string Text { get; private set; }

        /// <summary>
        /// Defocuses the control and stopps it's behaviour.
        /// </summary>
        public void Defocus()
        {
            this.IsFocused = false;
        }

        /// <summary>
        /// Focuses the control and executes it's behaviour (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        public void Focus()
        {
            this.IsFocused = true;
            this.Show();
            this.ScanInput();
        }

        public new void Hide()
        {
            this.Defocus();
            base.Hide();
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw(GraphicBuffer buffer)
        {
            buffer.BackgroundDrawingColor = this.BackgroundColor;
            buffer.ForegroundDrawingColor = this.ForegroundColor;

            string background = string.Empty;
            background = background.PadRight(this.Length, ' ');

            buffer.DrawLine(background, Coordinate.Origin);

            buffer.DrawLine(this.Text, Coordinate.Origin);
        }

        /// <summary>
        /// Raises the <see cref="TextEntered"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextEntered(EventArgs e)
        {
            this.TextEntered?.Invoke(this, e);
        }

        /// <summary>
        /// Scans the input.
        /// </summary>
        protected virtual void ScanInput()
        {
            bool cursorVisible = Console.CursorVisible;
            ConsoleKeyInfo key;

            Console.CursorVisible = true;

            do
            {
                this.OnInvalidated(EventArgs.Empty);

                int offset = this.Text.Length == this.Length ? 1 : 0;

                Console.SetCursorPosition(this.AbsoluteLocation.X + this.Text.Length - offset, this.AbsoluteLocation.Y);

                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (this.Text.Length > 0)
                        {
                            this.Text = this.Text.Substring(0, this.Text.Length - 1);
                        }
                    }
                    else if (this.Text.Length < this.Length)
                    {
                        this.Text += key.KeyChar;
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter && this.IsVisible);

            this.OnTextEntered(EventArgs.Empty);

            Console.CursorVisible = cursorVisible;
        }
    }
}
