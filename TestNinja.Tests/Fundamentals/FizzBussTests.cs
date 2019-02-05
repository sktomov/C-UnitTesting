using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestProject1.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutPut_DevisibleBy3And5_ReturnsText()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutPut_DevisibleBy3_ReturnsText()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutPut_DevisibleBy5_ReturnsText()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutPut_DevisibleByDifferentNumber_ReturnsNumberAsText()
        {
            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
