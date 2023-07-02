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
using MediaPlayerWithTest.src.Infrastructure.Repository;

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
        public void AddNewFile_ValidParameters_ReturnsTrue()
        {
            int playListId = 1;
            int fileId = 1;
            int userId = 1;

            _mockPlayListRepository.Setup(r => r.AddNewFile(playListId, fileId, userId))
                .Returns(true);

            bool result = _playListService.AddNewFile(playListId, fileId, userId);

            Assert.True(result);
            _mockPlayListRepository.Verify(r => r.AddNewFile(playListId, fileId, userId), Times.Once);
        }

        [Fact]
        public void EmptyList_ValidParameters_ReturnsTrue()
        {
            int playListId = 1;
            int userId = 1;

            _mockPlayListRepository.Setup(r => r.EmptyList(playListId, userId))
                .Returns(true);

            bool result = _playListService.EmptyList(playListId, userId);

            Assert.True(result);
            _mockPlayListRepository.Verify(r => r.EmptyList(playListId, userId), Times.Once);
        }

        [Fact]
        public void RemoveFile_ValidParameters_ReturnsTrue()
        {
            int playListId = 1;
            int fileId = 1;
            int userId = 1;

            _mockPlayListRepository.Setup(r => r.RemoveFile(playListId, fileId, userId))
                .Returns(true);

            bool result = _playListService.RemoveFile(playListId, fileId, userId);

            Assert.True(result);
            _mockPlayListRepository.Verify(r => r.RemoveFile(playListId, fileId, userId), Times.Once);
        }
    }
}
