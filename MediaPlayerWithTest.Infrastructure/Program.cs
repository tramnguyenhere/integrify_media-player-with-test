using MediaPlayerWithTest.src.Application;
using MediaPlayerWithTest.src.Business.Sevice;
using MediaPlayerWithTest.src.Domain.Core;
using MediaPlayerWithTest.src.Infrastructure.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        // how client interact with application - via controllers
        var userRepository = new UserRepository();
        var userService = new UserService(userRepository);
        var userController = new UserController(userService);

        var mediaRepository = new MediaRepository();
        var mediaService = new MediaService(mediaRepository);
        var mediaController = new MediaController(mediaService);

        var playListRepository = new PlayListRepository(mediaRepository);
        var playListService = new PlayListService(playListRepository);
        var playListController = new PlayListController(playListService);

        /* command-line interface should be here. All the methods should be used from class controllers only */

        /* Media */

        // Check method CreateNewFiles
        Console.WriteLine("Method: CreateNewFiles");
        Console.WriteLine(".......");
        mediaController.CreateNewFile("Flower", "/path/to/file.mp3", TimeSpan.FromSeconds(340.0));
        mediaController.CreateNewFile("Solo", "/path/to/file.mp3", TimeSpan.FromSeconds(240.0));
        Console.WriteLine("--------------");

        // Check method GetAllFiles
        Console.WriteLine("Method: GetAllFiles");
        Console.WriteLine(".......");
        foreach (var mediaFile in mediaController.GetAllFiles())
        {
            Console.WriteLine(mediaFile.ToString());
        }
        Console.WriteLine("--------------");

        // Check method GetFileById
        Console.WriteLine("Method: GetFileById");
        Console.WriteLine(".......");
        Console.WriteLine(mediaController.GetFileById(1));

        // Check method  DeleteFileById
        Console.WriteLine("Method:  DeleteFileById");
        Console.WriteLine(".......");
        mediaController.DeleteFileById(1);
        Console.WriteLine("--------------");

        /* User */
        userController.AddNewUser("Tram Nguyen");
        userController.AddNewUser("John Doe");
        userController.GetAllList(2);
    }
}
