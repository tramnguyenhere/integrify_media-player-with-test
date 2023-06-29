using MediaPlayerWithTest.src.Business.ServiceInterface;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Business.Sevice
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                ErrorHandler.HandleFileError("File name cannot be empty");
            }

            if (string.IsNullOrEmpty(filePath))
            {
                ErrorHandler.HandleFileError("File path cannot be empty");
            }
            _mediaRepository.CreateNewFile(fileName, filePath, duration);

            return new MediaFile(fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
            if (id < 0)
            {
                ErrorHandler.HandleFileError("Id is invalid");
                return false;
            }

            _mediaRepository.DeleteFileById(id);
            return true;
        }

        public List<MediaFile> GetAllFiles()
        {
            return _mediaRepository.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
            if (id < 0)
            {
                ErrorHandler.HandleFileError("Id is invalid");
            }

            return _mediaRepository.GetFileById(id);
        }
    }
}
