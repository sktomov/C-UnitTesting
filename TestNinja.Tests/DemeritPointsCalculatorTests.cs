using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace UnitTestProject1
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private  DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1000)]
        public void CalculateDemeritPoints_InvalidInput_ThrowsAnException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(65)]
        public void CalculateDemeritPoints_InputInLimit_ReturnsZero(int speed)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }

        public void CalculateDemeritPoints_InputAboveLimit_ReturnsDemeritPoints()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(99);

            Assert.That(result, Is.EqualTo(4));
        }
    }
}
