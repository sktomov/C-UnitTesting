using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestProject1
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;

        [SetUp]
        public void SetUp()
        {
            _customerController = new CustomerController();
        }

        [Test]
        public void GetCustomer_CalledWithZeroId_ReturnsNotFoundResult()
        {
            var result = _customerController.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_CalledPossitiveId_ReturnsNotFoundResult()
        {
            var result = _customerController.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
