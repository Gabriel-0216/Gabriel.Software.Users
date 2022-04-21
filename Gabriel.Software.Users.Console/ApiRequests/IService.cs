using Gabriel.Software.Users.Console.Users;

namespace Gabriel.Software.Users.Console.ApiRequests;

public interface IService
{
    Task<ApiResponse> Get(User user);
}