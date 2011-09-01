namespace FlagConsole.Controls
{
    /// <summary>
    /// Provides methods for focusable controls
    /// </summary>
    public interface IFocusable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IFocusable"/> is focused.
        /// </summary>
        /// <value>
        /// true if focused; otherwise, false.
        /// </value>
        bool IsFocused { get; }

        /// <summary>
        /// Focuses the control and executes it's behaviour (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        void Focus();

        /// <summary>
        /// Defocuses the control and stopps it's behaviour.
        /// </summary>
        void Defocus();
    }
}