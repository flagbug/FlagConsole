using System;
using FlagConsole.Drawing;

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

            var screen = new DemoScreen { Size = new Size(79, 49) };
            screen.Activate();
        }
    }
}