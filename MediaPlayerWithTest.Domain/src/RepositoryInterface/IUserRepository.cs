using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.src.Domain.RepositoryInterface
{
    public interface IUserRepository
    {
        public User AddNewUser(string name);
        public List<User> GetAllUsers();
        void AddNewList(string name, int userId);
        void RemoveOneList(int listId, int userId);
        void RemoveAllLists(int userId);
        void EmptyOneList(int listId, int userId);
        public List<PlayList> GetAllList(int userId);
        public PlayList GetListById(int listId);
    }
}
