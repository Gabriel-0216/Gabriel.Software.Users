namespace Gabriel.Software.Users.Console.Users;

public class User
{
    public string UserName { get; private set; }

    public User(string userName)
    {
        UserName = userName;
    }
}