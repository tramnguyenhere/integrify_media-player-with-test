using System;
using MediaPlayerWithTest.src.Business;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Infrastructure.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        private readonly List<PlayList> _playlistRepository;
        private readonly List<MediaFile> _mediaFiles;

        public PlayListRepository(List<MediaFile> mediaFiles)
        {
            _playlistRepository = new();
            _mediaFiles = mediaFiles;
        }

        public PlayList AddNewFile(int playListId, int fileId, int userId)
        {
            var playlist = _playlistRepository.FirstOrDefault(p => p.GetId == playListId);

            if (playlist != null)
            {
                var mediaFile = _mediaFiles.FirstOrDefault(f => f.GetId == fileId);

                if (mediaFile != null)
                {
                    playlist.AddNewFile(mediaFile, userId);
                    return playlist;
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
            var playlist = _playlistRepository.FirstOrDefault(p => p.GetId == playListId);

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
            var playlist = _playlistRepository.FirstOrDefault(p => p.GetId == playListId);

            if (playlist != null)
            {
                var mediaFile = _mediaFiles.FirstOrDefault(f => f.GetId == fileId);

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
