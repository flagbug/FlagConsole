using System;
using System.Collections.Generic;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    /// <summary>
    /// Represents a label that can show a text
    /// </summary>
    public class Label : Control
    {
        /// <summary>
        /// Gets or sets the text that is displayed in the label.
        /// </summary>
        /// <value>
        /// The text that is displayed in the label.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        public Label()
        {
            this.Text = String.Empty;
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        protected override void Draw(GraphicBuffer buffer)
        {
            buffer.ForegroundDrawingColor = this.ForegroundColor;
            buffer.BackgroundDrawingColor = this.BackgroundColor;

            buffer.DrawRectangle(' ', Coordinate.Origin, this.Size, true);

            var words = new List<string>();
            words.AddRange(this.Text.Split(' ')); //Split text into words

            var lines = new List<string>();

            // If there is only one word, draw it immediately.
            // This fixes a bug, which caues a cut-off at the end of a line
            // (the cut-off for only one word is desired)
            if (words.Count == 1)
            {
                lines.Add(words[0]);
            }

            else
            {
                do
                {
                    string line = String.Empty;
                    bool first = true;

                    for (int i = 0; i < words.Count; i++)
                    {
                        if (line.Length + words[0].Length < this.Size.Width) //check if the line fits into the label
                        {
                            string space = first ? String.Empty : " ";
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
            }

            for (int i = 0; i < lines.Count; i++)
            {
                buffer.DrawLine(lines[i], new Coordinate(0, i));
            }
        }
    }
}