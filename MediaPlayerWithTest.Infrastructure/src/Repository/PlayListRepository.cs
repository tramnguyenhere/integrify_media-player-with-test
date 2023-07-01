using System;
using MediaPlayerWithTest.src.Business;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Infrastructure.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        private readonly List<PlayList> _playLists;
        private readonly IMediaRepository _mediaFileRepository;

        public PlayListRepository(IMediaRepository mediaFileRepository)
        {
            _playLists = new();
            _mediaFileRepository = mediaFileRepository;
        }

        public bool AddNewFile(int playListId, int fileId, int userId)
        {
            var playlist = _playLists.FirstOrDefault(p => p.GetId == playListId);

            if (playlist != null)
            {
                var mediaFile =_mediaFileRepository.GetFileById(fileId);

                if (mediaFile != null)
                {
                    return playlist.AddNewFile(mediaFile, userId);
                }
                else
                {
                    throw new FileNotFoundException("Media file not found.");
                }
            }
            else
            {
                throw new FileNotFoundException("Playlist not found.");
            }
        }

        public bool EmptyList(int playListId, int userId)
        {
            var playlist = _playLists.FirstOrDefault(p => p.GetId == playListId);

            if (playlist != null)
            {
                playlist.EmptyList(userId);
                return true;
            }
            else
            {
                ErrorHandler.HandleFileNotFound();
                return false;
            }
        }

        public bool RemoveFile(int playListId, int fileId, int userId)
        {
            var playlist = _playLists.FirstOrDefault(p => p.GetId == playListId);

            if (playlist != null)
            {
                var mediaFile = _mediaFileRepository.GetFileById(fileId);

                if (mediaFile != null)
                {
                    playlist.RemoveFile(mediaFile, userId);
                    return true;
                }
                else
                {
                    ErrorHandler.HandleFileNotFound();
                    return false;
                }
            }
            else
            {
                ErrorHandler.HandleFileNotFound();
                return false;
            }
        }
    }
}
