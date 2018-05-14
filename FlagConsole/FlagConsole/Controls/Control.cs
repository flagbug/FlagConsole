﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Control.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Base class for all controls
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    using System;

    using FlagConsole.Drawing;

    /// <summary>
    /// Base class for all controls
    /// </summary>
    public abstract class Control
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        protected Control()
        {
            this.IsVisible = true;
            this.RelativeLocation = Coordinate.Origin;
            this.Size = new Size();
            this.ForegroundColor = Console.ForegroundColor;
            this.BackgroundColor = Console.BackgroundColor;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the control requires redrawing.
        /// </summary>
        public event EventHandler Invalidated;

        #endregion

        /// <summary>
        /// Gets the absolute location in the console.
        /// </summary>
        public virtual Coordinate AbsoluteLocation => this.RelativeLocation + this.Parent.AbsoluteLocation;

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>
        /// The background color for the control.
        /// </value>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color for the control.
        /// </summary>
        /// <value>
        /// The foreground color for the control.
        /// </value>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets a value indicating whether the control is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible { get; private set; }

        /// <summary>
        /// Gets or sets the parent <see cref="Container"/> that contains the control.
        /// </summary>
        /// <value>
        /// The parent <see cref="Container"/> that contains the control.
        /// </value>
        public Container Parent { get; set; }

        /// <summary>
        /// Gets or sets the relative location to the parent <see cref="Container"/>.
        /// </summary>
        /// <value>
        /// The relative location to the parent <see cref="Container"/>.
        /// </value>
        public Coordinate RelativeLocation { get; set; }

        /// <summary>
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>
        /// The size of the control.
        /// </value>
        public Size Size { get; set; }

        /// <summary>
        /// Gets the top <see cref="Container"/>.
        /// </summary>
        public virtual Container Top => this.Parent.Top;

        public virtual void Hide()
        {
            this.IsVisible = false;
        }

        /// <summary>
        /// Invalidates the control and causes a redraw.
        /// </summary>
        public void Invalidate()
        {
            this.OnInvalidated(EventArgs.Empty);
        }

        public virtual void Show()
        {
            this.IsVisible = true;
        }

        /// <summary>
        /// Updates the control if <see cref="IsVisible"/> is set to true.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        public virtual void Update(GraphicBuffer buffer)
        {
            if (this.IsVisible)
            {
                this.Draw(buffer);
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        protected abstract void Draw(GraphicBuffer buffer);

        /// <summary>
        /// Raises the <see cref="Invalidated"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnInvalidated(EventArgs e)
        {
            this.Invalidated?.Invoke(this, e);
        }
    }
}
