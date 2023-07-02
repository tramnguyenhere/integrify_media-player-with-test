using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.src.Business.ServiceInterface
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public User AddNewUser(string name);
        void AddNewList(string name, int userId);
        void RemoveOneList(int listId, int userId);
        void RemoveAllLists(int userId);
        void EmptyOneList(int listId, int userId);
        public List<PlayList> GetAllList(int userId);
        public PlayList GetListById(int listId);
    }
}