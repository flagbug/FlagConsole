using FlagConsole.Measure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlagConsole.UnitTests
{
    /// <summary>
    ///This is a test class for PointTest and is intended
    ///to contain all PointTest Unit Tests
    ///</summary>
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void PointConstructorTest()
        {
            int x = 5;
            int y = 15;
            Point target = new Point(x, y);

            Assert.AreEqual(5, target.X);
            Assert.AreEqual(15, target.Y);
        }

        [TestMethod]
        public void PointEmptyConstructorTest()
        {
            Point target = new Point();

            Assert.AreEqual(0, target.X);
            Assert.AreEqual(0, target.Y);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod]
        public void AddTest()
        {
            Point target = new Point(5, 15);
            Point position = new Point(5, 15);
            Point expected = new Point(10, 30);
            Point actual;

            actual = target.Add(position);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod]
        public void CloneTest()
        {
            Point target = new Point(5, 15);
            object expected = new Point(5, 15);
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
            Point target = new Point(5, 15);
            object obj = new Point(5, 15);
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
            Point target = new Point(5, 15);
            object obj = new Point(15, 5);
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
            Point target = new Point(5, 15);
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
            Point target = new Point(5, 15);
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
            Point target = new Point(5, 15);
            Point position = new Point(5, 15);
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
            Point target = new Point(5, 15);
            Point position = new Point(15, 5);
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
            Point target = new Point(5, 15);
            Point position = null;
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
            Point target = new Point(5, 15);
            Point position = target;
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
            int positionHash1 = new Point().GetHashCode();
            int positionHash2 = new Point(1, 1).GetHashCode();
            int positionHash3 = new Point(2, 2).GetHashCode();

            Assert.IsTrue(positionHash1 != positionHash2 && positionHash1 != positionHash3 && positionHash2 != positionHash3);
        }

        /// <summary>
        ///A test for op_Addition
        ///</summary>
        [TestMethod]
        public void op_AdditionTest()
        {
            Point positionA = new Point(5, 15);
            Point positionB = new Point(5, 15);
            Point expected = new Point(10, 30);
            Point actual;

            actual = (positionA + positionB);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod]
        public void op_EqualityTest()
        {
            Point positionA = new Point(5, 15);
            Point positionB = new Point(5, 15);
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
            Point positionA = new Point(5, 15);
            Point positionB = new Point(15, 5);
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
            Point positionA = new Point(5, 15);
            Point positionB = null;
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
            Point positionA = new Point(5, 15);
            Point positionB = positionA;
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
            Point positionA = new Point(5, 15);
            Point positionB = new Point(10, 30);
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
            Point positionA = new Point(5, 15);
            Point positionB = new Point(5, 15);
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
            Point positionA = new Point(5, 15);
            Point positionB = null;
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
            Point positionA = new Point(5, 15);
            Point positionB = positionA;
            bool expected = false;
            bool actual;

            actual = positionA != positionB;

            Assert.AreEqual(expected, actual);
        }
    }
}