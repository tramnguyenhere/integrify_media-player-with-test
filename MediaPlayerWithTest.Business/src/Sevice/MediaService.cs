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
            _mediaRepository.CreateNewFile(fileName, filePath, duration);
        }

        public void DeleteFileById(int id)
        {
            _mediaRepository.DeleteFileById(id);
        }

        public void GetAllFiles()
        {
            _mediaRepository.GetAllFiles();
        }

        public void GetFileById(int id)
        {
            _mediaRepository.GetFileById(id);
        }
    }
}