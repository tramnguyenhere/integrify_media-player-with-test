using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;
using MediaPlayerWithTest.src.Business.ServiceInterface;
using MediaPlayerWithTest.src.Business.Sevice;
using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.Tests.src.Business.Tests
{
    public class PlayListServiceTest
    {
        private Mock<IPlayListRepository> _mockPlayListRepository;
        private IPlayListService _playListService;

        public PlayListServiceTest()
        {
            _mockPlayListRepository = new();
            _playListService = new PlayListService(_mockPlayListRepository.Object);
        }

        [Fact]
        public void AddNewFile_ReturnTrue()
        {
            // Arrange
            int playListId = 1;
            int fileId = 2;
            int userId = 3;

            // Act
            var result = _playListService.AddNewFile(playListId, fileId, userId);

            // Assert
            _mockPlayListRepository.Verify(
                x => x.AddNewFile(playListId, fileId, userId),
                Times.Once
            );
            Assert.True(result);
        }
    }
}
