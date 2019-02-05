using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace UnitTestProject1.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IVideoRepository> _videoRepository;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_videoRepository.Object);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnsEmptyString()
        {
            _videoRepository.Setup(r => r.GetUnProcessedVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
    }
}
