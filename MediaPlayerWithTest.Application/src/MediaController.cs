using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.src.Business.ServiceInterface;
using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.src.Application
{
    public class MediaController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public bool CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            return _mediaService.CreateNewFile(fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
            return _mediaService.DeleteFileById(id);
        }

        public List<MediaFile> GetAllFiles()
        {
            return _mediaService.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
            return _mediaService.GetFileById(id);
        }
    }
}
