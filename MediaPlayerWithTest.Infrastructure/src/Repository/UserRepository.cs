using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new();
        }

        public void AddNewList(string name, int userId)
        {
            var user = _users.FirstOrDefault(user => user.GetId == userId);
            if(user == null) {
                throw new ArgumentException("User not found");
            } else {
                user?.Lists.Add(new PlayList(name, userId));
            }
        }

        public User AddNewUser(string name)
        {
            var user = new User(name);
            _users.Add(user);
            return user;
        }

        public void EmptyOneList(int listId, int userId)
        {
            var user = _users.FirstOrDefault(user => user.GetId == userId);
            var list = user!.Lists.FirstOrDefault(list => list.GetId == listId);
            list!.EmptyList(userId);
        }

        public List<PlayList> GetAllList(int userId)
        {
            var user = _users.FirstOrDefault(user => user.GetId == userId);
            if(user == null) {
                throw new ArgumentException("User not found");
            } else {
                return user.Lists;
            }
        }

        public PlayList GetListById(int listId)
        {
            var user = _users.FirstOrDefault(user => user.Lists.Any(list => list.GetId == listId));
            
            if (user == null) {
                throw new ArgumentException("List is not available in any user data");
            } else {
                return user.Lists.FirstOrDefault(list => list.GetId == listId);
            }
        }

        public void RemoveAllLists(int userId)
        {
            var user = _users.FirstOrDefault(user => user.GetId == userId);
            user!.Lists.Clear();
        }

        public void RemoveOneList(int listId, int userId)
        {
            var user = _users.FirstOrDefault(user => user.GetId == userId);
            var toBeRemovedList = user!.Lists.FirstOrDefault(list => list.GetId == listId);

            user.Lists.Remove(toBeRemovedList);
        }
    }
}
