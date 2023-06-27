using System.Data;

namespace MediaPlayerWithTest.src.Business
{
    public class ErrorHandler
    {
        public static Exception HandleFileError(string message)
        {
            throw new ArgumentException(message);
        }

        public static Exception HandleErrorInDatabase(string message)
        {
            throw new DataException(message);
        }
    }
}