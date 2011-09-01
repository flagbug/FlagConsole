using System;

namespace FlagConsole.Measure
{
    /// <summary>
    /// Provides a immutable size, which encapsulates a width and a height
    /// </summary>
    [Serializable]
    public class Size : ICloneable, IEquatable<Size>
    {
        private readonly int height;
        private readonly int width;

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        public Size()
        {
            this.height = 0;
            this.width = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Size(int width, int height)
        {
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new Size(this.Width, this.Height);
        }

        /// <summary>
        /// Converts the <see cref="Size"/> to a <see cref="System.Drawing.Size"/>.
        /// </summary>
        /// <returns>A <see cref="System.Drawing.Size"/></returns>
        public System.Drawing.Size ToSystemDrawingSize()
        {
            return new System.Drawing.Size(this.Width, this.Height);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Size size = obj as Size;

            if (size == null || this.GetType() != size.GetType())
            {
                return false;
            }

            return this.Height == size.Height && this.Width == size.Width;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Size other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { Height = this.Height, Width = this.Width }.GetHashCode();
        }
    }
}