namespace FlagConsole.Drawing
{
    using System.Collections.Generic;
    using System.Windows;

    internal class Ellipse : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class.
        /// </summary>
        /// <param name="midPoint">The mid point.</param>
        /// <param name="a">The radius.</param>
        /// <param name="b">The b.</param>
        /// <param name="token">The token.</param>
        public Ellipse(Coordinate midPoint, int a, int b, char token)
            : base(token)
        {
            this.Centre = midPoint;
            this.A = a;
            this.B = b;
        }

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
        /// Gets or sets the mid point.
        /// </summary>
        /// <value>
        /// The mid point.
        /// </value>
        public Coordinate Centre { get; set; }

        /// <summary>
        /// Draws the ellipse.
        /// </summary>
        /// <param name="buffer">The <see cref="GraphicBuffer"/> to draw on.</param>
        public override void Draw(GraphicBuffer buffer)
        {
            var points = RasterEllipse(
                this.Centre.X,
                this.Centre.Y,
                this.A + (int)(this.A / 1.75), // Compensate the proportions of the symbols in the console
                this.B);

            foreach (Point point in points)
            {
                buffer.DrawPixel(this.Token, new Coordinate((int)point.X, (int)point.Y));
            }
        }

        private static IEnumerable<Point> RasterEllipse(int xMid, int yMid, int a, int b)
        {
            int dx = 0;
            int dy = b;
            long a2 = a * a;
            long b2 = b * b;
            long error = b2 - (2 * b - 1) * a2;

            do
            {
                yield return new Point(xMid + dx, yMid + dy);
                yield return new Point(xMid - dx, yMid + dy);
                yield return new Point(xMid - dx, yMid - dy);
                yield return new Point(xMid + dx, yMid - dy);

                long error2 = 2 * error;

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
                yield return new Point(xMid + dx, yMid);
                yield return new Point(xMid - dx, yMid);
            }
        }
    }
}
