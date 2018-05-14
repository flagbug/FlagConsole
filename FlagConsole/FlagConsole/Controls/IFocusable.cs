﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFocusable.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Provides methods for focusable controls
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides methods for focusable controls
    /// </summary>
    public interface IFocusable
    {
        /// <summary>
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        /// <value>
        /// true if the control has input focus; otherwise, false.
        /// </value>
        bool IsFocused { get; }

        /// <summary>
        /// Defocuses the control and stops it's behavior.
        /// </summary>
        void Defocus();

        /// <summary>
        /// Focuses the control and executes it's behavior (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        void Focus();
    }
}
