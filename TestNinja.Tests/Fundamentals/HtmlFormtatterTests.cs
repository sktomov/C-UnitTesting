using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestProject1.Fundamentals
{
    [TestFixture]
    public class HtmlFormtatterTests
    {
        [Test]
        [TestCase("alabala")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string text)
        {
            //Arange
            var formatter = new HtmlFormatter();
            //Act
            var result = formatter.FormatAsBold("alabala");
            //Asert

            //Specific
            Assert.That(result, Is.EqualTo($"<strong>{text}</strong>").IgnoreCase);

            //General
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain(text));
        }
    }
}
