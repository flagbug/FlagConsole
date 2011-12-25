using System;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides a control, where the user can type text.
    /// </summary>
    public class TextBox : Control, IFocusable
    {
        private string text;

        /// <summary>
        /// Gets or sets the current text of the <see cref="TextBox"/>.
        /// </summary>
        /// <value>
        /// The current text of the <see cref="TextBox"/>.
        /// </value>
        public string Text
        {
            get { return this.text; }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnTextChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of characters the user can type into the <see cref="TextBox"/>.
        /// </summary>
        /// <value>
        /// The maximum number of characters the user can type into the <see cref="TextBox"/>.
        /// </value>
        public int MaxLength { get; set; }

        /// <summary>
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        /// <value>
        /// true if the control has input focus; otherwise, false.
        /// </value>
        public bool IsFocused { get; private set; }

        /// <summary>
        /// Occurs when the input has been submitted.
        /// </summary>
        public event EventHandler TextSubmitted;

        /// <summary>
        /// Occurs when the text has changed.
        /// </summary>
        public event EventHandler TextChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        public TextBox()
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
        /// Defocuses the control and stops it's behaviour.
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
            background = background.PadRight(this.Size.Width, ' ');

            buffer.DrawLine(background, Coordinate.Origin);

            buffer.DrawLine(this.Text, Coordinate.Origin);
        }

        /// <summary>
        /// Raises the <see cref="TextSubmitted"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextSubmitted(EventArgs e)
        {
            if (this.TextSubmitted != null)
            {
                this.TextSubmitted(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="TextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextChanged(EventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
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
                this.Invalidate();

                int offset = this.Text.Length == this.MaxLength ? 1 : 0;

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

                    else if (this.Text.Length < this.MaxLength)
                    {
                        this.Text += key.KeyChar;
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter && this.IsVisible);

            this.OnTextSubmitted(EventArgs.Empty);

            this.Defocus();

            Console.CursorVisible = cursorVisible;
        }
    }
}