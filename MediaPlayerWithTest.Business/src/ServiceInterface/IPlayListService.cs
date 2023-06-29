namespace MediaPlayerWithTest.src.Business.ServiceInterface
{
    public interface IPlayListService
    {
        public bool AddNewFile(int playListId, int fileId, int userId);
        public bool RemoveFile(int playListId, int fileId, int userId);
        public bool EmptyList(int playListId, int userId);
    }
}
