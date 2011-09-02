using System;
using System.Collections.Generic;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class GenericLine : Line
    {
        private static void Swap<T>(ref T lhs, ref T rhs) { T temp; temp = lhs; lhs = rhs; rhs = temp; }

        private Point EndPoint { get; set; }

        public GenericLine(Point startPoint, Point endPoint)
            : base(startPoint, 0, '#')
        {
            this.EndPoint = endPoint;
        }

        public override void Draw()
        {
            foreach (Point point in Line(this.Location.X, this.Location.Y, this.EndPoint.X, this.EndPoint.Y))
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(this.Token);
            }
        }

        public static IEnumerable<Point> Line(int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                Swap<int>(ref x0, ref y0);
                Swap<int>(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                Swap<int>(ref x0, ref x1);
                Swap<int>(ref y0, ref y1);
            }

            int dX = (x1 - x0);
            int dY = (y1 - y0);
            int err = (dX / 2);
            int ystep = (y0 < y1 ? 1 : -1);
            int y = y0;

            for (int x = x0; x <= x1; ++x)
            {
                if (steep)
                {
                    yield return new Point(y, x);
                }

                else
                {
                    yield return new Point(x, y);
                }

                err = err - dY;

                if (err < 0)
                {
                    y += ystep; err += dX;
                }
            }
        }
    }
}