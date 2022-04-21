using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gabriel.Software.Users.Console.Users;
using RestSharp;

namespace Gabriel.Software.Users.Console.ApiRequests;

public class Service : IService
{
    private readonly HttpClient _httpClient;

    public Service()
    {
        _httpClient = new HttpClient();
    }
    public async Task<ApiResponse> Get(User user)
    {
        
        using var http = new HttpClient();
        var url = new Uri($"{Endpoints.ENDPOINT}{user.UserName}");
        var result = await http.GetAsync(url);
        var resultContent = await result.Content.ReadAsStringAsync();
        return new ApiResponse()
        {
            Response = resultContent,
            Endpoint = url.ToString(),
        };
    }
}