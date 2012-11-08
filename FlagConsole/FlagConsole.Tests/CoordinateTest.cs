using FlagConsole.Drawing;
using NUnit.Framework;

namespace FlagConsole.Tests
{
    [TestFixture]
    public class CoordinateTest
    {
        [Test]
        public void AddTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(5, 15);
            var expected = new Coordinate(10, 30);

            Coordinate actual = target.Add(position);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CloneTest()
        {
            var target = new Coordinate(5, 15);
            object expected = new Coordinate(5, 15);

            object actual = target.Clone();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EqualsInverseTest()
        {
            var target = new Coordinate(5, 15);
            object obj = new Coordinate(15, 5);
            const bool expected = false;

            bool actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EqualsNullTest()
        {
            var target = new Coordinate(5, 15);
            object obj = null;
            const bool expected = false;

            bool actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EqualsReferenceTest()
        {
            var target = new Coordinate(5, 15);
            object obj = target;
            const bool expected = true;

            bool actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EqualsTest()
        {
            var target = new Coordinate(5, 15);
            object obj = new Coordinate(5, 15);
            const bool expected = true;

            bool actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenericEqualsInverseTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(15, 5);
            const bool expected = false;

            bool actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenericEqualsNullTest()
        {
            var target = new Coordinate(5, 15);
            Coordinate position = null;
            const bool expected = false;

            bool actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenericEqualsReferenceTest()
        {
            var target = new Coordinate(5, 15);
            Coordinate position = target;
            const bool expected = true;

            bool actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenericEqualsTest()
        {
            var target = new Coordinate(5, 15);
            var position = new Coordinate(5, 15);
            const bool expected = true;

            bool actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHashCodeTest()
        {
            int positionHash1 = Coordinate.Origin.GetHashCode();
            int positionHash2 = new Coordinate(1, 1).GetHashCode();
            int positionHash3 = new Coordinate(2, 2).GetHashCode();

            Assert.IsTrue(positionHash1 != positionHash2 && positionHash1 != positionHash3 && positionHash2 != positionHash3);
        }

        [Test]
        public void op_AdditionTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            var expected = new Coordinate(10, 30);

            Coordinate actual = (positionA + positionB);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_EqualityInverseTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(15, 5);
            const bool expected = false;

            bool actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_EqualityNullTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            const bool expected = false;

            bool actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_EqualityReferenceTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = positionA;
            const bool expected = true;

            bool actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_EqualityTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            const bool expected = true;

            bool actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_InequalityInverseTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(5, 15);
            const bool expected = false;

            bool actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_InequalityNullTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            const bool expected = true;

            bool actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_InequalityReferenceTest()
        {
            var positionA = new Coordinate(5, 15);
            Coordinate positionB = positionA;
            const bool expected = false;

            bool actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_InequalityTest()
        {
            var positionA = new Coordinate(5, 15);
            var positionB = new Coordinate(10, 30);
            const bool expected = true;

            bool actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PointConstructorTest()
        {
            const int x = 5;
            const int y = 15;
            var target = new Coordinate(x, y);

            Assert.AreEqual(5, target.X);
            Assert.AreEqual(15, target.Y);
        }

        [Test]
        public void PointEmptyConstructorTest()
        {
            Coordinate target = Coordinate.Origin;

            Assert.AreEqual(0, target.X);
            Assert.AreEqual(0, target.Y);
        }
    }
}