namespace Gabriel.Software.Users.Console.Logging;

public class AppLog
{
    private static string LogRuns = "LogRuns.txt";
    private static string Log = "Log.txt";
    private string AppPath { get; set; }

    public void SetAppPath(string path)
    {
        AppPath = path;
    }
    public void Write(string text)
    {
        using StreamWriter file = new(Log, append: true);
        file.WriteLine(text);
    }

    public void WriteDateLastRun(DateTime lastRun)
    {
        using StreamWriter file = new(LogRuns, append: false);
        file.WriteLine(lastRun.ToString());
    }

    public DateTime GetLastRun()
    {
        DateTime dateTime = DateTime.UtcNow;
        using var file = new StreamReader(LogRuns);
        string? line;
        while ((line = file.ReadLine()) != null)
        {
            var dateTimeTryParse = DateTime.TryParse(line, out dateTime);
        }

        return dateTime;
    }

}