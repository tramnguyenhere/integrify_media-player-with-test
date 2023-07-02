using MediaPlayerWithTest.src.Domain.Core;
using System;

namespace MediaPlayerWithTest.src.Domain.RepositoryInterface
{
    public interface IMediaRepository
    {
        void Play(int fileId);
        void Pause(int fileId);
        void Stop(int fileId);
        public bool CreateNewFile(string fileName, string filePath, TimeSpan duration);
        public bool DeleteFileById(int fileId);
        public List<MediaFile> GetAllFiles();
        public MediaFile GetFileById(int fileId);
    }
}
