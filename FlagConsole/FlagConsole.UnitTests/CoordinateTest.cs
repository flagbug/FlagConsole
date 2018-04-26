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

            Coordinate actual = target.Add(position);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CloneTest()
        {
            var target = new Coordinate(5, 15);
            object expected = new Coordinate(5, 15);

            object actual = target.Clone();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualsInverseTest()
        {
            var target = new Coordinate(5, 15);
            object obj = new Coordinate(15, 5);
            const bool Expected = false;

            bool actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void EqualsNullTest()
        {
            var target = new Coordinate(5, 15);
            object obj = null;
            const bool Expected = false;

            bool actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void EqualsReferenceTest()
        {
            var target = new Coordinate(5, 15);
            object obj = target;
            const bool Expected = true;

            bool actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var target = new Coordinate(5, 15);
            object obj = new Coordinate(5, 15);
            const bool Expected = true;

            bool actual = target.Equals(obj);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsInverseTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(15, 5);
            const bool Expected = false;

            bool actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsNullTest()
        {
            var target = new Coordinate(5, 15);
            Coordinate position = null;
            const bool Expected = false;

            bool actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsReferenceTest()
        {
            var target = new Coordinate(5, 15);
            Coordinate position = target;
            const bool Expected = true;

            bool actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GenericEqualsTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(5, 15);
            const bool Expected = true;

            bool actual = target.Equals(position);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GetHashCodeTest()
        {
            int positionHash1 = Coordinate.Origin.GetHashCode();
            int positionHash2 = new Coordinate(1, 1).GetHashCode();
            int positionHash3 = new Coordinate(2, 2).GetHashCode();

            Assert.True(
                positionHash1 != positionHash2 && positionHash1 != positionHash3 && positionHash2 != positionHash3);
        }

        [Fact]
        public void op_AdditionTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            var expected = new Coordinate(10, 30);

            Coordinate actual = positionA + positionB;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_EqualityInverseTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(15, 5);
            const bool Expected = false;

            bool actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_EqualityNullTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            const bool Expected = false;

            bool actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_EqualityReferenceTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = positionA;
            const bool Expected = true;

            bool actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_EqualityTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            const bool Expected = true;

            bool actual = positionA == positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_InequalityInverseTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            const bool Expected = false;

            bool actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_InequalityNullTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            const bool Expected = true;

            bool actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_InequalityReferenceTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = positionA;
            const bool Expected = false;

            bool actual = positionA != positionB;

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void op_InequalityTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(10, 30);
            const bool Expected = true;

            bool actual = positionA != positionB;

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
            Coordinate target = Coordinate.Origin;

            Assert.Equal(0, target.X);
            Assert.Equal(0, target.Y);
        }
    }
}
