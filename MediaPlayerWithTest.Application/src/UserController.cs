using MediaPlayerWithTest.src.Business.ServiceInterface;
using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.src.Application
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> GetAllUsers() {
            return _userService.GetAllUsers();
        }

        public User AddNewUser(string name) {
            return _userService.AddNewUser(name);
        }

        public void AddNewList(string name, int userId)
        {
            _userService.AddNewList(name, userId);
        }

        public void EmptyOneList(int listId, int userId)
        {
            _userService.EmptyOneList(listId, userId);
        }

        public List<PlayList> GetAllList(int userId)
        {
            return _userService.GetAllList(userId);
        }

        public PlayList GetListById(int listId)
        {
            return _userService.GetListById(listId);
        }

        public void RemoveAllLists(int userId)
        {
            _userService.RemoveAllLists(userId);
        }

        public void RemoveOneList(int listId, int userId)
        {
           _userService.RemoveOneList(listId, userId);
        }
    }
}