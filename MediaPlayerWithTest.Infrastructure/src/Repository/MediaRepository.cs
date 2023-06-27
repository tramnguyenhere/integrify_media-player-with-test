using System;
using MediaPlayerWithTest.src.Business;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Infrastructure.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly List<MediaFile> _mediaFiles;

        public MediaRepository()
        {
            _mediaFiles = new();
        }

        public MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            var newMediaFile = new MediaFile(fileName, filePath, duration);
            _mediaFiles.Add(newMediaFile);

            return newMediaFile;
        }

        public bool DeleteFileById(int fileId)
        {
            var toBeDeletedMedia = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);

            if (toBeDeletedMedia != null)
            {
                _mediaFiles.Remove(toBeDeletedMedia);
                return true;
            }
            else
            {
                ErrorHandler.HandleFileNotFound();
                return false;
            }
        }

        public List<MediaFile> GetAllFiles()
        {
            return _mediaFiles;
        }

        public MediaFile GetFileById(int fileId)
        {
            var media = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);

            if (media != null)
            {
                return media;
            }
            else
            {
                throw new FileNotFoundException("Media file not found");
            }
        }

        public void Pause(int fileId)
        {
            var mediaFile = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);

            if (mediaFile != null)
            {
                mediaFile.Pause();
            }
            else
            {
                ErrorHandler.HandleFileNotFound();
            }
        }

        public void Play(int fileId)
        {
            var mediaFile = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);

            if (mediaFile != null)
            {
                mediaFile.Play();
            }
            else
            {
                ErrorHandler.HandleFileNotFound();
            }
        }

        public void Stop(int fileId)
        {
            var mediaFile = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);

            if (mediaFile != null)
            {
                mediaFile.Stop();
            }
            else
            {
                ErrorHandler.HandleFileNotFound();
            }
        }
    }
}
