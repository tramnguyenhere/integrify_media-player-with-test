using MediaPlayerWithTest.src.Business;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Infrastructure.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly List<MediaFile> _mediaFiles;

        public MediaRepository() {
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

            if(toBeDeletedMedia != null) {
                _mediaFiles.Remove(toBeDeletedMedia);
                return true; 
            } else {
                ErrorHandler.HandleErrorInDatabase("Media file not found in database");
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

            if(media != null) {
                return media;
            } else {
                throw new Exception("Media file not found");
            }
        }

        public void Pause(int fileId)
        {
            throw new NotImplementedException();
        }

        public void Play(int fileId)
        {
            throw new NotImplementedException();
        }

        public void Stop(int fileId)
        {
            throw new NotImplementedException();
        }
    }
}