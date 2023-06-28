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
            _mockMediaRepository.Setup(m => m.CreateNewFile(fileName, filePath, duration));

            MediaFile newMediaFile = _mediaService.CreateNewFile(fileName, filePath, duration);

            _mockMediaRepository.Verify(
                x => x.CreateNewFile(fileName, filePath, duration),
                Times.Once()
            );
            Assert.NotNull(newMediaFile);
            Assert.Equal(expectedMediaFile.FileName, newMediaFile.FileName);
            Assert.Equal(expectedMediaFile.FilePath, newMediaFile.FilePath);
            Assert.Equal(expectedMediaFile.Duration, newMediaFile.Duration);
        }

        [Fact]
        public void DeleteFileById_ValidId_ReturnTrue()
        {
            int id = 1;

            bool result = _mediaService.DeleteFileById(id);

            _mockMediaRepository.Verify(m => m.DeleteFileById(id), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void DeleteFileById_InValidId_ReturnFalse_ShouldThrowException()
        {
            int id = -4;
            string expectedErrorMessage = "Id is invalid";

            Exception exception = Assert.Throws<Exception>(() => _mediaService.DeleteFileById(id));
            Assert.Equal(expectedErrorMessage, exception.Message);
            _mockMediaRepository.Verify(m => m.DeleteFileById(id), Times.Never);
        }

        [Fact]
        public void GetAllFiles_ShouldReturnListOfMediaFiles()
        {
            List<MediaFile> expectedMediaFiles =
                new()
                {
                    new MediaFile("Shutdown", "/path/to/file.mp3", TimeSpan.FromSeconds(140.0)),
                    new MediaFile("Flower", "/path/to/file.mp3", TimeSpan.FromSeconds(340.0)),
                    new MediaFile("Solo", "/path/to/file.mp3", TimeSpan.FromSeconds(240.0)),
                };
            _mockMediaRepository.Setup(m => m.GetAllFiles()).Returns(expectedMediaFiles);

            List<MediaFile> actualMediaFiles = _mediaService.GetAllFiles();

            Assert.Equal(expectedMediaFiles, actualMediaFiles);
            _mockMediaRepository.Verify(m => m.GetAllFiles(), Times.Once);
        }

        [Fact]
        public void GetFileById_ValidId_ShouldReturnOneMediaFile()
        {
            int id = 1;
            MediaFile expectedMediaFile = new("Shutdown", "Blackpink", TimeSpan.FromSeconds(140.0));

            _mockMediaRepository.Setup(m => m.GetFileById(id)).Returns(expectedMediaFile);

            MediaFile actualMediaFile = _mediaService.GetFileById(id);

            Assert.Equal(expectedMediaFile, actualMediaFile);
            _mockMediaRepository.Verify(m => m.GetFileById(id), Times.Once);
        }

        [Fact]
        public void GetFileById_InvalidId_ShouldThrowException()
        {
            int id = -4;
            string expectedErrorMessage = "Id is invalid";

            Exception exception = Assert.Throws<Exception>(() => _mediaService.GetFileById(id));
            Assert.Equal(expectedErrorMessage, exception.Message);
            _mockMediaRepository.Verify(m => m.GetFileById(id), Times.Never);
        }
    }
}
