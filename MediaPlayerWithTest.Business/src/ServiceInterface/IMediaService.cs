using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.src.Business.ServiceInterface
{
    public interface IMediaService
    {
        public bool CreateNewFile(string fileName, string filePath, TimeSpan duration);
        public bool DeleteFileById(int id);
        public List<MediaFile> GetAllFiles();
        public MediaFile GetFileById(int id);
    }
}
