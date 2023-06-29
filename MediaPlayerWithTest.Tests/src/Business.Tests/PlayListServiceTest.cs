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
        private Mock<PlayListRepository> _mockPlayListRepository;
        private IPlayListService _playListService;

        public PlayListServiceTest()
        {
            _mockPlayListRepository = new(
                new List<MediaFile>
                {
                    new MediaFile("Shutdown", "/path/to/file.mp3", TimeSpan.FromSeconds(140.0)),
                    new MediaFile("Flower", "/path/to/file.mp3", TimeSpan.FromSeconds(340.0)),
                    new MediaFile("Solo", "/path/to/file.mp3", TimeSpan.FromSeconds(240.0)),
                }
            );

            _playListService = new PlayListService(_mockPlayListRepository.Object);
        }

        [Fact]
        public void AddNewFile_ExistingPlaylistAndMediaFile_ReturnsTrue() { }
    }
}
