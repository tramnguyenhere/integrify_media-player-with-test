using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.src.Business.ServiceInterface;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Business.Sevice
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddNewUser(string name)
        {
            return _userRepository.AddNewUser(name);
        }


        public void AddNewList(string name, int userId)
        {
            _userRepository.AddNewList(name, userId);
            Console.WriteLine($"Playlist \"{name}\" added successfully!");
        }

        public void EmptyOneList(int listId, int userId)
        {
            _userRepository.EmptyOneList(listId, userId);
        }

        public List<PlayList> GetAllList(int userId)
        {
            return _userRepository.GetAllList(userId);
        }

        public PlayList GetListById(int listId)
        {
            return _userRepository.GetListById(listId);
        }

        public void RemoveAllLists(int userId)
        {
            _userRepository.RemoveAllLists(userId);
        }

        public void RemoveOneList(int listId, int userId)
        {
            _userRepository.RemoveOneList(listId, userId);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}