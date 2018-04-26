namespace FlagConsole.Demo
{
    using System;

    using FlagConsole.Drawing;

    internal class Program
    {
        private static void Main()
        {
            Console.Title = "FlagConsole Demo Application";

            Console.WindowHeight = 50;
            Console.WindowWidth = 80;
            Console.BufferHeight = 50;
            Console.BufferWidth = 80;

            Console.CursorVisible = false;

            var screen = new DemoScreen { Size = new Size(79, 49) };
            screen.Activate();
        }
    }
}
