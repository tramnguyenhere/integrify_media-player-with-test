using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.src.Domain.RepositoryInterface;

namespace MediaPlayerWithTest.src.Infrastructure.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        public void AddNewFile(int playListId, int fileId, int userId)
        {
            throw new NotImplementedException();
        }

        public void EmptyList(int playListId, int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFile(int playListId, int fileId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}