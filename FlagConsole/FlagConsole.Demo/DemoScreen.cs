using System;
using FlagConsole.Controls;
using FlagConsole.Drawing;

namespace FlagConsole.Demo
{
    internal class DemoScreen : Screen
    {
        private readonly Menu<Action> mainMenu;

        private readonly Panel mainMenuPanel;
        private Panel presentationPanel;

        private readonly Label mainMenuTextLabel;

        public DemoScreen()
        {
            this.mainMenuPanel = new Panel { Size = new Size(30, 30), RelativeLocation = new Coordinate(2, 1) };
            this.Controls.Add(this.mainMenuPanel);

            this.mainMenuTextLabel =
                new Label
                {
                    Size = new Size(30, 7),
                    Text = "This is the main menu. You can select items with the UP and DOWN arrows or the W and S keys (this can be customized). Press enter if you want to see the presentation."
                };
            this.mainMenuPanel.Controls.Add(mainMenuTextLabel);

            this.mainMenu = new Menu<Action> { RelativeLocation = new Coordinate(0, 7), Size = new Size(15, 10) };
            this.mainMenu.Items.Add(new MenuItem<Action>("Label", this.ShowLabelDemo));
            this.mainMenu.Items.Add(new MenuItem<Action>("ListView", this.ShowListViewDemo));
            this.mainMenu.Items.Add(new MenuItem<Action>("TextBox", this.ShowTextBoxDemo));
            this.mainMenu.Items.Add(new MenuItem<Action>("Rectangle", this.ShowRectangleDemo));
            this.mainMenu.Items.Add(new MenuItem<Action>("Line", this.ShowLineDemo));
            this.mainMenu.Items.Add(new MenuItem<Action>("Ellipse", this.ShowEllipseDemo));
            this.mainMenu.Items.Add(new MenuItem<Action>("Exit", this.Exit));

            this.mainMenu.UpKeys.Add(ConsoleKey.W);
            this.mainMenu.DownKeys.Add(ConsoleKey.S);

            this.mainMenu.ItemChosen += mainMenu_ItemChosen;

            this.mainMenuPanel.Controls.Add(this.mainMenu);
        }

        public void Activate()
        {
            this.Update(new GraphicBuffer(this.Size));
            this.mainMenu.Focus();
        }

        private void mainMenu_ItemChosen(object sender, MenuEventArgs<Action> e)
        {
            e.Item.Value.Invoke();
            this.mainMenu.Focus();
        }

        private void SwitchDemoPanel(Panel panel)
        {
            this.Controls.Remove(this.presentationPanel);
            this.presentationPanel = panel;
            this.presentationPanel.Size = new Size(45, 40);
            this.presentationPanel.RelativeLocation = new Coordinate(35, 7);
            this.Controls.Add(this.presentationPanel);
        }

        private void ShowLabelDemo()
        {
            this.SwitchDemoPanel(new LabelDemoPanel());
        }

        private void ShowListViewDemo()
        {
            this.SwitchDemoPanel(new ListViewDemoPanel());
        }

        private void ShowTextBoxDemo()
        {
            var panel = new TextBoxDemoPanel();
            this.SwitchDemoPanel(panel);
            panel.Activate();
        }

        private void ShowRectangleDemo()
        {
            this.SwitchDemoPanel(new RectangleDemoPanel());
        }

        private void ShowLineDemo()
        {
            this.SwitchDemoPanel(new LineDemoPanel());
        }

        private void ShowEllipseDemo()
        {
            this.SwitchDemoPanel(new EllipseDemoPanel());
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}