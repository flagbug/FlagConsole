// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Base class for all containers
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using FlagConsole.Drawing;

    /// <inheritdoc />
    /// <summary>
    /// Base class for all containers
    /// </summary>
    public abstract class Container : Control
    {
        #region Fields

        private readonly ObservableCollection<Control> controls;

        #endregion

        #region Constructors and Destructors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        protected Container()
        {
            this.controls = new ObservableCollection<Control>();
            this.controls.CollectionChanged += this.ControlsCollectionChanged;
        }

        #endregion

        /// <summary>
        /// Gets the underlying controls.
        /// </summary>
        /// <value>
        /// The underlying controls.
        /// </value>
        public ICollection<Control> Controls => this.controls;

        /// <inheritdoc />
        /// <summary>
        /// Updates the control if <see cref="Control.IsVisible"/> is set to true.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        public override void Update(GraphicBuffer buffer)
        {
            base.Update(buffer);

            if (this.IsVisible)
            {
                foreach (var control in this.controls)
                {
                    var localBuffer = new GraphicBuffer(control.Size);

                    control.Update(localBuffer);

                    buffer.Merge(localBuffer, control.RelativeLocation);
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw(GraphicBuffer buffer)
        {
            buffer.BackgroundDrawingColor = this.BackgroundColor;
            buffer.ForegroundDrawingColor = this.ForegroundColor;

            buffer.DrawRectangle(' ', Coordinate.Origin, this.Size, true);
        }

        /// <summary>
        /// Handles the Invalidated event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ControlInvalidated(object sender, EventArgs e)
        {
            this.OnInvalidated(EventArgs.Empty);
        }

        /// <summary>
        /// Handles the CollectionChanged event of the controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void ControlsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    foreach (Control control in e.NewItems)
                    {
                        control.Parent = this;
                        control.Invalidated += this.ControlInvalidated;

                        this.OnInvalidated(EventArgs.Empty);
                    }

                    break;
                }

                case NotifyCollectionChangedAction.Remove:
                {
                    foreach (Control control in e.OldItems)
                    {
                        control.Parent = null;
                        control.Invalidated -= this.ControlInvalidated;

                        this.OnInvalidated(EventArgs.Empty);
                    }

                    break;
                }

                case NotifyCollectionChangedAction.Replace:
                    break;

                case NotifyCollectionChangedAction.Move:
                    break;

                case NotifyCollectionChangedAction.Reset:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
