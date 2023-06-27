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

        public void CreateNewFile(string fileName, string filePath, TimeSpan duration)
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
        }

        public void DeleteFileById(int id)
        {
            if(id < 0) {
                ErrorHandler.HandleFileError("Id is invalid");
            }

            _mediaRepository.DeleteFileById(id);
        }

        public void GetAllFiles()
        {
            _mediaRepository.GetAllFiles();
        }

        public void GetFileById(int id)
        {
            if(id < 0) {
                ErrorHandler.HandleFileError("Id is invalid");
            }

            _mediaRepository.GetFileById(id);
        }
    }
}