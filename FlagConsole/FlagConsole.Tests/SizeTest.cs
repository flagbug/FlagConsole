using FlagConsole.Drawing;

namespace FlagConsole.Tests
{
    using Xunit;

    public class SizeTest
    {
        [Fact]
        public void CloneTest()
        {
            var target = new Size(5, 15);
            object expected = new Size(5, 15);

            object actual = target.Clone();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var target = new Size(5, 15);
            var other = new Size(5, 15);
            const bool expected = true;

            bool actual = target.Equals(other);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GenericEqualsTest()
        {
            var target = new Size(5, 15);
            object obj = new Size(5, 15);
            const bool expected = true;

            bool actual = target.Equals(obj);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashCodeTest()
        {
            int sizeHash1 = new Size().GetHashCode();
            int sizeHash2 = new Size(1, 1).GetHashCode();
            int sizeHash3 = new Size(2, 2).GetHashCode();

            Assert.True(sizeHash1 != sizeHash2 && sizeHash1 != sizeHash3 && sizeHash2 != sizeHash3);
        }

        [Fact]
        public void SizeConstructorTest()
        {
            const int width = 5;
            const int height = 15;
            var target = new Size(width, height);

            Assert.Equal(5, target.Width);
            Assert.Equal(15, target.Height);
        }

        [Fact]
        public void SizeEmptyConstructorTest()
        {
            var target = new Size();

            Assert.Equal(0, target.Width);
            Assert.Equal(0, target.Height);
        }
    }
}
