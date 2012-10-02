using FlagConsole.Drawing;
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
        ///A test for Clone
        ///</summary>
        [TestMethod]
        public void CloneTest()
        {
            var target = new Size(5, 15);
            object expected = new Size(5, 15);

            object actual = target.Clone();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void EqualsTest()
        {
            var target = new Size(5, 15);
            var other = new Size(5, 15);
            const bool expected = true;

            bool actual = target.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod]
        public void GenericEqualsTest()
        {
            var target = new Size(5, 15);
            object obj = new Size(5, 15);
            const bool expected = true;

            bool actual = target.Equals(obj);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod]
        public void GetHashCodeTest()
        {
            int sizeHash1 = new Size().GetHashCode();
            int sizeHash2 = new Size(1, 1).GetHashCode();
            int sizeHash3 = new Size(2, 2).GetHashCode();

            Assert.IsTrue(sizeHash1 != sizeHash2 && sizeHash1 != sizeHash3 && sizeHash2 != sizeHash3);
        }

        /// <summary>
        ///A test for Size Constructor
        ///</summary>
        [TestMethod]
        public void SizeConstructorTest()
        {
            const int width = 5;
            const int height = 15;
            var target = new Size(width, height);

            Assert.AreEqual(5, target.Width);
            Assert.AreEqual(15, target.Height);
        }

        /// <summary>
        ///A test for Size Constructor
        ///</summary>
        [TestMethod]
        public void SizeEmptyConstructorTest()
        {
            var target = new Size();

            Assert.AreEqual(0, target.Width);
            Assert.AreEqual(0, target.Height);
        }
    }
}