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

        public bool CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                ErrorHandler.HandleFileError("File name cannot be empty");
                return false;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                ErrorHandler.HandleFileError("File path cannot be empty");
                return false;
            }
            _mediaRepository.CreateNewFile(fileName, filePath, duration);
            Console.WriteLine($"\"{fileName}\" added successfully!");
            
            return true;
        }

        public bool DeleteFileById(int id)
        {
            if (id < 0)
            {
                ErrorHandler.HandleFileError("Id is invalid");
                return false;
            }

            var toBeDeletedFile = _mediaRepository.GetFileById(id);

            if (toBeDeletedFile != null) {
                Console.WriteLine($"\"{toBeDeletedFile.FileName}\" deleted successfully");
                return _mediaRepository.DeleteFileById(id);
            } else {
                ErrorHandler.HandleFileError("File not found");
                return false;
            }
            
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
