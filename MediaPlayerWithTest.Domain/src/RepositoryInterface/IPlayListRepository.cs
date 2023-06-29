using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.src.Domain.RepositoryInterface
{
    public interface IPlayListRepository
    {
        public bool AddNewFile(int playListId, int fileId, int userId);
        public bool RemoveFile(int playListId, int fileId, int userId);
        public bool EmptyList(int playListId, int userId);
    }
}
