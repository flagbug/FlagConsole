﻿namespace FlagConsole.Controls
{
    using System.Collections.Generic;

    using FlagConsole.Drawing;

    /// <summary>
    /// Provides a list view, that displays items in a table with one column
    /// </summary>
    /// <typeparam name="T">Type of the item that gets displayed</typeparam>
    public class ListView<T> : ListControl
    {
        private readonly List<T> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListView&lt;T&gt;"/> class.
        /// </summary>
        public ListView()
        {
            this.items = new List<T>();
            this.Bullet = '+';
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public ICollection<T> Items => this.items;

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        protected override void Draw(GraphicBuffer buffer)
        {
            buffer.ForegroundDrawingColor = this.ForegroundColor;
            buffer.BackgroundDrawingColor = this.BackgroundColor;

            buffer.DrawRectangle(' ', Coordinate.Origin, this.Size, true);

            for (int i = 0; i < this.items.Count && i < this.Size.Height; i++)
            {
                string bulletString = this.DisplayBullets ? this.Bullet + " " : string.Empty;

                buffer.DrawLine(bulletString + this.items[i], new Coordinate(0, i));
            }
        }
    }
}
