namespace Gabriel.Software.Users.Console.ApiRequests;

public class ApiResponse
{
    public string Endpoint { get; set; } = string.Empty;
    public string? Response { get; set; }

    public override string ToString()
    {
        return $"Request realizado no endpoint: {Endpoint}, Resposta da api: {Response}";
    }
}