using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;

namespace FlagConsole.Controls
{
    public class TextField : Control
    {
        private ConsoleColor foreColor = ConsoleColor.Black;
        public ConsoleColor ForeColor
        {
            get
            {
                return this.foreColor;
            }

            set
            {
                this.foreColor = value;
            }
        }

        private ConsoleColor backColor = ConsoleColor.White;
        public ConsoleColor BackColor
        {
            get
            {
                return this.backColor;
            }

            set
            {
                this.backColor = value;
            }
        }

        private string input = "";
        public string Input
        {
            get
            {
                return this.input;
            }
        }

        private int textFieldLength = 0;
        public int TextFieldLength
        {
            get
            {
                return this.textFieldLength;
            }

            set
            {
                this.textFieldLength = value;
            }
        }

        private ConsoleColor saveForeColor;
        private ConsoleColor saveBackColor;

        public event EventHandler InputEntered;

        protected virtual void OnInputEntered()
        {
            if (this.InputEntered != null)
            {
                this.InputEntered.Invoke(this, new EventArgs());
            }
        }

        public override void Activate()
        {
            if (this.ParentContainer.Activated)
            {
                this.Activated = true;
                Console.CursorVisible = true;
                this.saveBackColor = Console.BackgroundColor;
                this.saveForeColor = Console.ForegroundColor;

                this.ScanInput();
            }
        }

        public override void Deactivate()
        {
            this.Activated = false;
            this.input = "";
            Console.CursorVisible = false;
            this.ClearControl();
        }

        protected override void Show()
        {
            Console.BackgroundColor = this.backColor;
            Console.ForegroundColor = this.foreColor;
            this.CreateBackground();
            Console.Write(this.input);
        }

        protected void CreateBackground()
        {
            string background = "";

            for (int i = 0; i < this.textFieldLength; i++)
            {
                background += " ";
            }

            Console.BackgroundColor = this.backColor;
            Console.SetCursorPosition(this.AbsolutePosition.X, this.AbsolutePosition.Y);
            Console.Write(background);
            Console.SetCursorPosition(this.AbsolutePosition.X, this.AbsolutePosition.Y);
        }

        protected void ScanInput()
        {
            ConsoleKeyInfo key;

            do
            {
                this.Show();

                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (this.input.Length > 0)
                        {
                            this.input = this.input.Substring(0, this.input.Length - 1);
                        }
                    }

                    else if (this.input.Length < this.textFieldLength)
                    {
                        this.input += key.KeyChar.ToString();
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter && this.Activated);

            Console.BackgroundColor = this.saveBackColor;
            Console.ForegroundColor = this.saveForeColor;

            this.OnInputEntered();
        }

        /*
        /// <summary>
        /// Obsolete, because a textField has no frame
        /// </summary>
        protected override void DrawFrame()
        {
            
        }
         * */
    }
}
