using System;
using System.Collections.Generic;
using FlagConsole.Measure;

namespace FlagConsole.Drawing
{
    public class Ellipse : Shape
    {
        /// <summary>
        /// Gets or sets the mid point.
        /// </summary>
        /// <value>
        /// The mid point.
        /// </value>
        public Point Centre { get; set; }

        /// <summary>
        /// Gets or sets the size on the x-axis.
        /// </summary>
        /// <value>
        /// The size on the y-axis.
        /// </value>
        public int A { get; set; }

        /// <summary>
        /// Gets or sets the size on the y-axis.
        /// </summary>
        /// <value>
        /// The size on the y-axis.
        /// </value>
        public int B { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class.
        /// </summary>
        /// <param name="midPoint">The mid point.</param>
        /// <param name="a">The radius.</param>
        /// <param name="b">The b.</param>
        /// <param name="token">The token.</param>
        public Ellipse(Point midPoint, int a, int b, char token)
            : base(token)
        {
            this.Centre = midPoint;
            this.A = a;
            this.B = b;
        }

        /// <summary>
        /// Draws the circle.
        /// </summary>
        public override void Draw()
        {
            foreach (System.Windows.Point point in this.RasterEllipse(
                this.Centre.X,
                this.Centre.Y,
                this.A + (int)((double)this.A / (1.75)), //Compensate the proportions of the sympols in the console
                this.B))
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