// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoordinateTest.cs" company="???">
//   Copyright (c) ???. All rights reserved.
// </copyright>
// <summary>
//   Defines the CoordinateTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlagConsole.UnitTests
{
    using FlagConsole.Drawing;

    using Xunit;

    public class CoordinateTest
    {
        [Fact]
        public void AddTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(5, 15);
            var expected = new Coordinate(10, 30);

            var actual = target.Add(position);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CloneTest()
        {
            var target = new Coordinate(5, 15);
            object expected = new Coordinate(5, 15);

            var actual = target.Clone();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualsInverseTest()
        {
            var target = new Coordinate(5, 15);
            object obj = new Coordinate(15, 5);
            const bool Expected = false;

            var actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void EqualsNullTest()
        {
            var target = new Coordinate(5, 15);
            object obj = null;
            const bool Expected = false;

            var actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void EqualsReferenceTest()
        {
            var target = new Coordinate(5, 15);
            object obj = target;
            const bool Expected = true;

            var actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var target = new Coordinate(5, 15);
            object obj = new Coordinate(5, 15);
            const bool Expected = true;

            var actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsInverseTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(15, 5);
            const bool Expected = false;

            var actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsNullTest()
        {
            var target = new Coordinate(5, 15);
            Coordinate position = null;
            const bool Expected = false;

            var actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsReferenceTest()
        {
            var target = new Coordinate(5, 15);
            var position = target;
            const bool Expected = true;

            var actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(5, 15);
            const bool Expected = true;

            var actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GetHashCodeTest()
        {
            var positionHash1 = Coordinate.Origin.GetHashCode();
            var positionHash2 = new Coordinate(1, 1).GetHashCode();
            var positionHash3 = new Coordinate(2, 2).GetHashCode();

            Assert.True(
                        positionHash1 != positionHash2
                     && positionHash1 != positionHash3
                     && positionHash2 != positionHash3);
        }

        [Fact]
        public void OpAdditionTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            var expected = new Coordinate(10, 30);

            var actual = positionA + positionB;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OpEqualityInverseTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(15, 5);
            const bool Expected = false;

            var actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpEqualityNullTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            const bool Expected = false;

            var actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpEqualityReferenceTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = positionA;
            const bool Expected = true;

            var actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpEqualityTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            const bool Expected = true;

            var actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpInequalityInverseTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            const bool Expected = false;

            var actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpInequalityNullTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            const bool Expected = true;

            var actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpInequalityReferenceTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = positionA;
            const bool Expected = false;

            var actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void OpInequalityTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(10, 30);
            const bool Expected = true;

            var actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void PointConstructorTest()
        {
            const int X = 5;
            const int Y = 15;
            var target = new Coordinate(X, Y);

            Assert.Equal(5, target.X);
            Assert.Equal(15, target.Y);
        }

        [Fact]
        public void PointEmptyConstructorTest()
        {
            var target = Coordinate.Origin;

            Assert.Equal(0, target.X);
            Assert.Equal(0, target.Y);
        }
    }
}
