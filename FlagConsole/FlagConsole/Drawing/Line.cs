// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Line.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Base class for lines (horizontal line and vertical line)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.Drawing
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// Base class for lines (horizontal line and vertical line)
    /// </summary>
    internal class Line : Shape
    {
        #region Constructors and Destructors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="token">The token of which the line consists.</param>
        public Line(Coordinate startPoint, Coordinate endPoint, char token)
                : base(token)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        #endregion

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        public Coordinate EndPoint { get; set; }

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>
        /// The start point.
        /// </value>
        public Coordinate StartPoint { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="buffer">The graphic buffer.</param>
        public override void Draw(GraphicBuffer buffer)
        {
            foreach (var point in RasterLine(this.StartPoint.X, this.StartPoint.Y, this.EndPoint.X, this.EndPoint.Y))
            {
                buffer.DrawPixel(this.Token, point);
            }
        }

        private static IEnumerable<Coordinate> RasterLine(int xStart, int yStart, int xEnd, int yEnd)
        {
            var steep = Math.Abs(yEnd - yStart) > Math.Abs(xEnd - xStart);

            if (steep)
            {
                Swap(ref xStart, ref yStart);
                Swap(ref xEnd, ref yEnd);
            }

            if (xStart > xEnd)
            {
                Swap(ref xStart, ref xEnd);
                Swap(ref yStart, ref yEnd);
            }

            var dX = xEnd - xStart;
            var dY = yEnd - yStart;
            var error = dX / 2;
            var yStep = yStart < yEnd ? 1 : -1;
            var y = yStart;

            for (int x = xStart; x <= xEnd; ++x)
            {
                if (steep)
                {
                    yield return new Coordinate(y, x);
                }
                else
                {
                    yield return new Coordinate(x, y);
                }

                error = error - dY;

                if (error < 0)
                {
                    y += yStep;
                    error += dX;
                }
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var temp = first;

            first = second;
            second = temp;
        }
    }
}
