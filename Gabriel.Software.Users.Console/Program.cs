using Gabriel.Software.Users.Console.ApiRequests;
using Gabriel.Software.Users.Console.Logging;
using Gabriel.Software.Users.Console.Users;

public class Program
{
    public static void Main(string[] args)
    {
        var log = new AppLog();
        var appPath = $"Path: {Environment.GetCommandLineArgs()[0]}";
        var getLastRun = log.GetLastRun();
        VerifyIfCanRun(getLastRun);
        log.SetAppPath(appPath);
        log.WriteDateLastRun(DateTime.UtcNow);
        
        
        
        //REMEMBER TO REMOVE
        args = new[] {@"C:\Users\GABRI\Desktop\teste.txt"};
        
        if (args.Length == 0)
        {
            Console.WriteLine("You should pass the file path as a parameter");
            Console.WriteLine("Example: dotnet run \"teste\" ");
            return;
        }
        
        var filePath = args[0];
        var users = RetrieveDataPath(filePath);
        var apiService = new Service();
        foreach (var item in users)
        {
            var apiGetResult = apiService.Get(item).GetAwaiter().GetResult();
            Console.WriteLine(apiGetResult.ToString());
            log.Write(apiGetResult.ToString());
            Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

    private static IList<User> RetrieveDataPath(string filePath)
    {
        var userList = new List<User>();
        using var file = new StreamReader(filePath);
        string? line;
        while ((line = file.ReadLine()) != null)
        {
            userList.Add(new User(line));
        }

        return userList;
    }

    public static bool VerifyIfCanRun(DateTime lastRun)
    {
        if (!(DateTime.UtcNow > lastRun.AddSeconds(60))) return true;
        
        Console.WriteLine("Please await 60 seconds before trying to make another request.");
        Task.Delay(60);
        return true;
    }
}