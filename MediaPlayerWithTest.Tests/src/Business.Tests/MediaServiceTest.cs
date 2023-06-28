using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;
using MediaPlayerWithTest.src.Domain.Core;
using Xunit;
using MediaPlayerWithTest.src.Business.ServiceInterface;
using MediaPlayerWithTest.src.Business.Sevice;

namespace MediaPlayerWithTest.Tests.src.Business.Tests
{
    public class MediaServiceTest
    {
        private Mock<IMediaRepository> _mockMediaRepository;
        private IMediaService _mediaService;

        public MediaServiceTest()
        {
            _mockMediaRepository = new();
            _mediaService = new MediaService(_mockMediaRepository.Object);
        }

        [Fact]
        public void CreateNewFile_ValidData_ReturnNewMediaFile()
        {
            string fileName = "Hello";
            string filePath = "/path/to/file.mp3";
            TimeSpan duration = TimeSpan.FromSeconds(120.0);
            MediaFile expectedMediaFile = new(fileName, filePath, duration);
            _mockMediaRepository
                .Setup(m => m.CreateNewFile(fileName, filePath, duration))
                .Returns(expectedMediaFile);

            MediaFile newMediaFile = _mediaService.CreateNewFile(fileName, filePath, duration);

            Assert.NotNull(newMediaFile);
            _mockMediaRepository.Verify(
                x => x.CreateNewFile(fileName, filePath, duration),
                Times.Once()
            );
            Assert.Equal(expectedMediaFile.FileName, newMediaFile.FileName);
            Assert.Equal(expectedMediaFile.FilePath, newMediaFile.FilePath);
            Assert.Equal(expectedMediaFile.Duration, newMediaFile.Duration);
        }
    }
}
