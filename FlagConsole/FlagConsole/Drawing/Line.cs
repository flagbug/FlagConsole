using System;
using System.Collections.Generic;
using System.Linq;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    /// <summary>
    /// Base class for lines (horizontal line and vertical line)
    /// </summary>
    public class Line : Shape
    {
        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>
        /// The start point.
        /// </value>
        public Point StartPoint { get; set; }

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        public Point EndPoint { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="length">The lenght.</param>
        /// <param name="token">The token.</param>
        public Line(Point startPoint, Point endPoint, char token)
            : base(token)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        /// <summary>
        /// Draws the line.
        /// </summary>
        public override void Draw()
        {
            if (this.StartPoint.X == this.EndPoint.X)
            {
                this.DrawVerticalLine();
            }

            else if (this.StartPoint.Y == this.EndPoint.Y)
            {
                this.DrawHorizontalLine();
            }

            else
            {
                this.DrawGenericLine();
            }
        }

        /// <summary>
        /// Draws a horizontal line.
        /// </summary>
        private void DrawHorizontalLine()
        {
            string line = new string(Enumerable.Repeat(this.Token, this.EndPoint.X - this.StartPoint.X + 1).ToArray());
            System.Console.SetCursorPosition(this.StartPoint.X, this.StartPoint.Y);
            System.Console.Write(line);
        }

        /// <summary>
        /// Draws a vertical line.
        /// </summary>
        private void DrawVerticalLine()
        {
            for (int y = this.StartPoint.Y; y < this.EndPoint.Y + 1; y++)
            {
                System.Console.SetCursorPosition(this.StartPoint.X, y);
                System.Console.Write(this.Token);
            }
        }

        /// <summary>
        /// Draws a generic line.
        /// </summary>
        private void DrawGenericLine()
        {
            foreach (Point point in this.GetLinePoints(this.StartPoint.X, this.StartPoint.Y, this.EndPoint.X, this.EndPoint.Y))
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(this.Token);
            }
        }

        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp; temp = lhs;
            lhs = rhs; rhs = temp;
        }

        private IEnumerable<Point> GetLinePoints(int x0, int y0, int x1, int y1)
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