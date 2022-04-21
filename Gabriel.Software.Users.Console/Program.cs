using Gabriel.Software.Users.Console.Users;

public class Program
{
    public static void Main(string[] args)
    {
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

    }

    private static IEnumerable<User> RetrieveDataPath(string filePath)
    {
        using var file = new StreamReader(filePath);
        string? line;
        while ((line = file.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}