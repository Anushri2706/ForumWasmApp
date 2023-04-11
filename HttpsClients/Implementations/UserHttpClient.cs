using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Model;
using HttpsClients.ClientInterfaces;

namespace HttpsClients.Implementations;

public class UserHttpClient : IUserService
{
     
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        //make a POST request to /users sending the dto which is serialized to JSON and wrapped in stringcontent obj
        HttpResponseMessage response = await client.PostAsJsonAsync("/User", dto);
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response status code: {(int)response.StatusCode} {response.ReasonPhrase}");
        Console.WriteLine($"Response body: {result}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result)!;
        return user;
        
    }

    public async Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null)
    {
        string uri = "/users";
        if (!string.IsNullOrEmpty(usernameContains))
        {
            uri += $"?username={usernameContains}";
        }
        HttpResponseMessage response = await client.GetAsync("/User");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Console.WriteLine(result);

        IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
        
    }
}