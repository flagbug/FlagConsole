using System;
using System.Diagnostics;

namespace FlagConsole.Drawing
{
    /// <summary>
    /// Provides an immutable size, which encapsulates a width and a height
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    [DebuggerDisplay("Width = {Width}, Height = {Height}")]
    public class Size : ICloneable, IEquatable<Size>
    {
        private readonly int height;
        private readonly int width;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        public Size()
            : this(0, 0) { }

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
        /// Gets the height.
        /// </summary>
        public int Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public int Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="sizeA">The size A.</param>
        /// <param name="sizeB">The size B.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Size sizeA, Size sizeB)
        {
            return !(sizeA == sizeB);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="sizeA">The position A.</param>
        /// <param name="sizeB">The position B.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Size sizeA, Size sizeB)
        {
            //Check reference
            if (Object.ReferenceEquals(sizeA, sizeB))
                return true;

            //Check null (cast to object type to avoid infinite loop)
            if ((object)sizeA == null || (object)sizeB == null)
                return false;

            return sizeA.Height == sizeB.Height && sizeA.Width == sizeB.Width;
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
            var size = obj as Size;

            if (size == null)
            {
                return false;
            }

            return this.Equals(size);
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
            return new { this.Height, this.Width }.GetHashCode();
        }
    }
}