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
        /// Focuses the control and executes it's behaviour (e.g the selection of a menu or the input of a textfield)
        /// </summary>
        void Focus();

        /// <summary>
        /// Defocuses the control and stopps it's behaviour.
        /// </summary>
        void Defocus();
    }
}