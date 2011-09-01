using System;
using System.Collections.Generic;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Represents a label that can show a text
    /// </summary>
    public class Label : Control
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            List<string> words = new List<string>();
            words.AddRange(this.Text.Split(' ')); //Split text into words

            List<string> lines = new List<string>();

            do
            {
                string line = String.Empty;
                bool first = true;

                for (int i = 0; i < words.Count; i++)
                {
                    if (line.Length + words[0].Length < this.Size.Width) //check if the line fits into the label
                    {
                        string space = first ? "" : " ";
                        first = false;

                        line += space + words[0];
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
            while (words.Count > 0 && lines.Count < this.Size.Height);

            for (int i = 0; i < lines.Count; i++)
            {
                System.Console.SetCursorPosition(this.AbsoluteLocation.X, this.AbsoluteLocation.Y + i);
                System.Console.Write(lines[i]);
            }
        }
    }
}