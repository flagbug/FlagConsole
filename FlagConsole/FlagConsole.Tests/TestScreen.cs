using System;
using FlagConsole.Controls;
using FlagConsole.Measure;

namespace FlagConsole.Tests
{
    internal class TestScreen : Screen
    {
        private enum MainMenuAction
        {
            Item1,
            Item2,
            Item3
        }

        private Menu<Action> mainMenu;

        private Panel mainMenuPanel;
        private Panel presentationPanel;

        private Label mainManuTextLabel;

        public TestScreen()
        {
            this.mainMenuPanel = new Panel();
            this.mainMenuPanel.RelativeLocation = new Point(2, 2);
            this.Controls.Add(this.mainMenuPanel);

            this.mainManuTextLabel = new Label();
            this.mainManuTextLabel.Size = new Size(25, 1);
            this.mainManuTextLabel.Text = "This is the main menu.";
            this.mainMenuPanel.Controls.Add(mainManuTextLabel);

            this.mainMenu = new Menu<Action>();
            this.mainMenu.RelativeLocation = new Point(2, 2);
            this.mainMenu.Items.Add(new MenuItem<Action>("Label Presentation", this.ShowLabelPresentation));
            this.mainMenu.Items.Add(new MenuItem<Action>("Hide Text", this.HideText));
            this.mainMenu.Items.Add(new MenuItem<Action>("Show Text", this.ShowText));

            this.mainMenu.UpKeys.Add(ConsoleKey.W);
            this.mainMenu.DownKeys.Add(ConsoleKey.S);

            this.mainMenu.SelectionChanged += new EventHandler<MenuEventArgs<Action>>(mainMenu_SelectionChanged);

            this.mainMenuPanel.Controls.Add(this.mainMenu);
        }

        private void mainMenu_SelectionChanged(object sender, MenuEventArgs<Action> e)
        {
            e.Item.Value.Invoke();
        }

        public void Activate()
        {
            this.ShowLabelPresentation();
            this.Update();
            this.mainMenu.Focus();
        }

        public void SwitchPresentationPanel(Panel panel)
        {
            this.Controls.Remove(this.presentationPanel);
            this.presentationPanel = panel;
            this.Controls.Add(this.presentationPanel);
            this.Update();
        }

        public void ShowLabelPresentation()
        {
            this.SwitchPresentationPanel(new LabelPresentationPanel { RelativeLocation = new Point(35, 2) });
        }

        public void HideText()
        {
            this.mainManuTextLabel.IsVisible = false;
            this.Update();
        }

        public void ShowText()
        {
            this.mainManuTextLabel.IsVisible = true;
            this.Update();
        }
    }
}