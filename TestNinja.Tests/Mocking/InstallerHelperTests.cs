using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace UnitTestProject1.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownLoader> _fileDownLoader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownLoader = new Mock<IFileDownLoader>();
            _installerHelper = new InstallerHelper(_fileDownLoader.Object);
        }

        [Test]
        public void DownloadInstaller_FailDownLoad_ReturnsFalse()
        {
            _fileDownLoader.Setup(m => m.DownLoadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_SuccessDownLoad_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
