using System;
using FlagConsole.Measure;

namespace FlagConsole.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 80;
            Console.BufferHeight = 50;
            Console.BufferWidth = 80;

            DemoScreen screen = new DemoScreen();
            screen.Size = new Size(79, 49);
            screen.Activate();
        }
    }
}