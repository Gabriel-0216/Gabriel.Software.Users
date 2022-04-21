using Gabriel.Software.Users.Console.ApiRequests;
using Gabriel.Software.Users.Console.Logging;
using Gabriel.Software.Users.Console.Users;

namespace Gabriel.Software.Users.Console;

public static class Program
{
    public static void Main(string[] args)
    {
        var log = new AppLog();
        var appPath = $"Path: {Environment.GetCommandLineArgs()[0]}";
        var getLastRun = log.GetLastRun();
        VerifyIfCanRun(getLastRun);
        log.SetAppPath(appPath);

        //REMEMBER TO REMOVE
        args = new[] {@"C:\Users\GABRI\Desktop\teste.txt"};
        
        if (args.Length == 0)
        {
            System.Console.WriteLine("You should pass the file path as a parameter");
            System.Console.WriteLine("Example: dotnet run \"teste\" ");
            return;
        }
        log.Write($"File {args[0]}");
        var filePath = args[0];
        var users = RetrieveDataPath(filePath);
        log.Write($"{users.Count} users retrieved from the file");
        RequestToApi(users, log);
        log.WriteDateLastRun(DateTime.UtcNow);
        log.Write("Operation completed");
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

    private static void VerifyIfCanRun(DateTime lastRun)
    {
        if (DateTime.UtcNow > lastRun.AddSeconds(60)) return;

        System.Console.WriteLine("Please await 60 seconds before trying to make another request.");
        Thread.Sleep(60000);
    }

    private static void RequestToApi(IEnumerable<User> users, AppLog log)
    {
        var apiService = new Service();
        foreach (var item in users)
        {
            var apiGetResult = apiService.Get(item).GetAwaiter().GetResult();
            System.Console.WriteLine(apiGetResult.ToString());
            log.Write(apiGetResult.ToString());
            Thread.Sleep(5000);
        }
    }
}