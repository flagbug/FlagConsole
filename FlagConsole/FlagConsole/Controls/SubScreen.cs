// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Controls
{
    internal class SubScreen : Screen
    {
        #region Fields

        private readonly Screen parent;

        #endregion

        #region Constructors and Destructors

        public SubScreen(Screen parent)
        {
            this.parent = parent;
        }

        #endregion

        public override void Hide()
        {
            base.Hide();
            this.parent.Show();
        }

        public override void Show()
        {
            this.parent.Hide();
            base.Show();
        }
    }
}
