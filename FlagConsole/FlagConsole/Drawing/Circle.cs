using System;
using System.Collections.Generic;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class Circle : Shape
    {
        /// <summary>
        /// Gets or sets the mid point.
        /// </summary>
        /// <value>
        /// The mid point.
        /// </value>
        public Point MidPoint { get; set; }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        public int Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="midPoint">The mid point.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="token">The token.</param>
        public Circle(Point midPoint, int radius, char token)
            : base(token)
        {
            this.MidPoint = midPoint;
            this.Radius = radius;
        }

        /// <summary>
        /// Draws the circle.
        /// </summary>
        public override void Draw()
        {
            foreach (System.Windows.Point point in this.RasterEllipse(
                this.MidPoint.X,
                this.MidPoint.Y,
                this.Radius + (int)((double)this.Radius / (1.75)),
                this.Radius))
            {
                Console.SetCursorPosition((int)point.X, (int)point.Y);
                Console.Write(this.Token);
            }
        }

        private IEnumerable<System.Windows.Point> RasterEllipse(int xMid, int yMid, int a, int b)
        {
            int dx = 0;
            int dy = b;
            long a2 = a * a;
            long b2 = b * b;
            long error = b2 - (2 * b - 1) * a2;
            long error2;

            do
            {
                yield return new System.Windows.Point(xMid + dx, yMid + dy);
                yield return new System.Windows.Point(xMid - dx, yMid + dy);
                yield return new System.Windows.Point(xMid - dx, yMid - dy);
                yield return new System.Windows.Point(xMid + dx, yMid - dy);

                error2 = 2 * error;
                if (error2 < (2 * dx + 1) * b2)
                {
                    dx++;
                    error += (2 * dx + 1) * b2;
                }

                if (error2 > -(2 * dy - 1) * a2)
                {
                    dy--;
                    error -= (2 * dy - 1) * a2;
                }
            }
            while (dy >= 0);

            while (dx++ < a)
            {
                yield return new System.Windows.Point(xMid + dx, yMid);
                yield return new System.Windows.Point(xMid - dx, yMid);
            }
        }
    }
}