using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagConsole.Controls
{
    public class Label : Control
    {
        private string text = "";
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                this.Update();
            }
        }

        protected override void Show()
        {
            List<string> words = new List<string>();
            words.AddRange(((string)this.text.Clone()).Split(' '));

            List<string> lines = new List<string>();

            do
            {
                string line = "";

                for (int i = 0; i < words.Count; i++)
                {
                    if (line.Length + words[0].Length + 1 <= this.Size.Width)
                    {
                        line += " " + words[0];
                        words.Remove(words[0]);
                        i--;
                    }

                    else
                    {
                        break;
                    }
                }

                lines.Add(line);
            }
            while (words.Count > 0);

            for (int i = 0; i < lines.Count; i++)
            {
                Console.SetCursorPosition(this.AbsolutePosition.X, this.AbsolutePosition.Y + i);
                Console.Write(lines[i]);
            }
        }
    }
}
