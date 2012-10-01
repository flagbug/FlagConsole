using FlagConsole.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlagConsole.UnitTests
{
    /// <summary>
    ///This is a test class for PointTest and is intended
    ///to contain all PointTest Unit Tests
    ///</summary>
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void PointConstructorTest()
        {
            int x = 5;
            int y = 15;
            Coordinate target = new Coordinate(x, y);

            Assert.AreEqual(5, target.X);
            Assert.AreEqual(15, target.Y);
        }

        [TestMethod]
        public void PointEmptyConstructorTest()
        {
            Coordinate target = Coordinate.Origin;

            Assert.AreEqual(0, target.X);
            Assert.AreEqual(0, target.Y);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod]
        public void AddTest()
        {
            Coordinate target = new Coordinate(5, 15);
            Coordinate position = new Coordinate(5, 15);
            Coordinate expected = new Coordinate(10, 30);
            Coordinate actual;

            actual = target.Add(position);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod]
        public void CloneTest()
        {
            Coordinate target = new Coordinate(5, 15);
            object expected = new Coordinate(5, 15);
            object actual;

            actual = target.Clone();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void EqualsTest()
        {
            Coordinate target = new Coordinate(5, 15);
            object obj = new Coordinate(5, 15);
            bool expected = true;
            bool actual;

            actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void EqualsInverseTest()
        {
            Coordinate target = new Coordinate(5, 15);
            object obj = new Coordinate(15, 5);
            bool expected = false;
            bool actual;

            actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void EqualsNullTest()
        {
            Coordinate target = new Coordinate(5, 15);
            object obj = null;
            bool expected = false;
            bool actual;

            actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void EqualsReferenceTest()
        {
            Coordinate target = new Coordinate(5, 15);
            object obj = target;
            bool expected = true;
            bool actual;

            actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void GenericEqualsTest()
        {
            Coordinate target = new Coordinate(5, 15);
            Coordinate position = new Coordinate(5, 15);
            bool expected = true;
            bool actual;

            actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void GenericEqualsInverseTest()
        {
            Coordinate target = new Coordinate(5, 15);
            Coordinate position = new Coordinate(15, 5);
            bool expected = false;
            bool actual;

            actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void GenericEqualsNullTest()
        {
            Coordinate target = new Coordinate(5, 15);
            Coordinate position = null;
            bool expected = false;
            bool actual;

            actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void GenericEqualsReferenceTest()
        {
            Coordinate target = new Coordinate(5, 15);
            Coordinate position = target;
            bool expected = true;
            bool actual;

            actual = target.Equals(position);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod]
        public void GetHashCodeTest()
        {
            int positionHash1 = Coordinate.Origin.GetHashCode();
            int positionHash2 = new Coordinate(1, 1).GetHashCode();
            int positionHash3 = new Coordinate(2, 2).GetHashCode();

            Assert.IsTrue(positionHash1 != positionHash2 && positionHash1 != positionHash3 && positionHash2 != positionHash3);
        }

        /// <summary>
        ///A test for op_Addition
        ///</summary>
        [TestMethod]
        public void op_AdditionTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = new Coordinate(5, 15);
            Coordinate expected = new Coordinate(10, 30);
            Coordinate actual;

            actual = (positionA + positionB);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod]
        public void op_EqualityTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = new Coordinate(5, 15);
            bool expected = true;
            bool actual;

            actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod]
        public void op_EqualityInverseTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = new Coordinate(15, 5);
            bool expected = false;
            bool actual;

            actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod]
        public void op_EqualityNullTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            bool expected = false;
            bool actual;

            actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod]
        public void op_EqualityReferenceTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = positionA;
            bool expected = true;
            bool actual;

            actual = (positionA == positionB);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod]
        public void op_InequalityTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = new Coordinate(10, 30);
            bool expected = true;
            bool actual;

            actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod]
        public void op_InequalityInverseTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = new Coordinate(5, 15);
            bool expected = false;
            bool actual;

            actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod]
        public void op_InequalityNullTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = null;
            bool expected = true;
            bool actual;

            actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod]
        public void op_InequalityReferenceTest()
        {
            Coordinate positionA = new Coordinate(5, 15);
            Coordinate positionB = positionA;
            bool expected = false;
            bool actual;

            actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }
    }
}