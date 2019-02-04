using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestProject1
{
    [TestFixture]
    public class MathTests
    {
        private  Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void GetOddNumbers_LimitIsGreatherThanZero_ReturnsOddNumbersToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));
            Assert.That(result, Is.Ordered);
        }

        [Test]
        public void GetOddNumbers_LimitIsNegative_ReturnsEmptyArray()
        {
            var result = _math.GetOddNumbers(-5);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetOddNumbers_LimitIsZero_ReturnsEmptyArray()
        {
            var result = _math.GetOddNumbers(0);

            Assert.That(result, Is.Empty);
        }
    }
}
