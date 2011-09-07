using System;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a text field where the user can do an input
    /// </summary>
    public class TextField : Control, IFocusable
    {
        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public virtual string Text { get; private set; }

        /// <summary>
        /// Gets or sets the length of the text field.
        /// </summary>
        /// <value>
        /// The length of the text field.
        /// </value>
        public virtual int Length { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IFocusable"/> is focused.
        /// </summary>
        /// <value>
        /// true if focused; otherwise, false.
        /// </value>
        public virtual bool IsFocused { get; set; }

        /// <summary>
        /// Occurs when the input has been entered.
        /// </summary>
        public event EventHandler TextEntered;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextField"/> class.
        /// </summary>
        public TextField()
        {
            this.Text = String.Empty;
            this.BackgroundColor = ConsoleColor.White;
            this.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Focuses the control and executes it's behaviour (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        public void Focus()
        {
            this.IsFocused = true;
            this.IsVisible = true;
            this.ScanInput();
        }

        /// <summary>
        /// Defocuses the control and stopps it's behaviour.
        /// </summary>
        public void Defocus()
        {
            this.IsFocused = false;
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw(GraphicBuffer buffer)
        {
            buffer.BackgroundDrawingColor = this.BackgroundColor;
            buffer.ForegroundDrawingColor = this.ForegroundColor;

            string background = String.Empty;
            background = background.PadRight(this.Length, ' ');

            buffer.DrawLine(background, Coordinate.Origin);

            buffer.DrawLine(this.Text, Coordinate.Origin);
        }

        /// <summary>
        /// Raises the <see cref="E:TextEntered"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextEntered(EventArgs e)
        {
            if (this.TextEntered != null)
            {
                this.TextEntered(this, e);
            }
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

                key = System.Console.ReadKey(true);

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
                        this.Text += key.KeyChar.ToString();
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter && this.IsVisible);

            this.OnTextEntered(EventArgs.Empty);

            Console.CursorVisible = cursorVisible;
        }
    }
}