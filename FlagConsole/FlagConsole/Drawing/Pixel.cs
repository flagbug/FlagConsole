﻿namespace FlagConsole.Drawing
{
    using System;

    internal class Pixel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pixel"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="foregroundColor">The foreground color.</param>
        /// <param name="backgroundColor">The background color.</param>
        public Pixel(char token, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.Token = token;
            this.ForegroundColor = foregroundColor;
            this.BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Gets the background color.
        /// </summary>
        /// <value>
        /// The background color.
        /// </value>
        public ConsoleColor BackgroundColor { get; private set; }

        /// <summary>
        /// Gets the foreground color.
        /// </summary>
        /// <value>
        /// The foreground color.
        /// </value>
        public ConsoleColor ForegroundColor { get; private set; }

        /// <summary>
        /// Gets the token.
        /// </summary>
        public char Token { get; private set; }
    }
}
