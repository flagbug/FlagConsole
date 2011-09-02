using FlagConsole.Measure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlagConsole.UnitTests
{
    /// <summary>
    ///This is a test class for SizeTest and is intended
    ///to contain all SizeTest Unit Tests
    ///</summary>
    [TestClass]
    public class SizeTest
    {
        /// <summary>
        ///A test for Size Constructor
        ///</summary>
        [TestMethod]
        public void SizeConstructorTest()
        {
            int width = 5;
            int height = 15;
            Size target = new Size(width, height);

            Assert.AreEqual(5, target.Width);
            Assert.AreEqual(15, target.Height);
        }

        /// <summary>
        ///A test for Size Constructor
        ///</summary>
        [TestMethod]
        public void SizeEmptyConstructorTest()
        {
            Size target = new Size();

            Assert.AreEqual(0, target.Width);
            Assert.AreEqual(0, target.Height);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod]
        public void CloneTest()
        {
            Size target = new Size(5, 15);
            object expected = new Size(5, 15);
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
            Size target = new Size(5, 15);
            Size other = new Size(5, 15);
            bool expected = true;
            bool actual;

            actual = target.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void GenericEqualsTest()
        {
            Size target = new Size(5, 15);
            object obj = new Size(5, 15);
            bool expected = true;
            bool actual;

            actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            int sizeHash1 = new Size().GetHashCode();
            int sizeHash2 = new Size(1, 1).GetHashCode();
            int sizeHash3 = new Size(2, 2).GetHashCode();

            Assert.IsTrue(sizeHash1 != sizeHash2 && sizeHash1 != sizeHash3 && sizeHash2 != sizeHash3);
        }
    }
}