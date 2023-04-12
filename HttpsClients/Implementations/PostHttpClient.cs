using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.Model;
using HttpsClients.ClientInterfaces;

namespace HTTPClient.Implementation;

public class PostHttpClient: IPostService

{

    private readonly System.Net.Http.HttpClient client;

    public PostHttpClient(System.Net.Http.HttpClient httpClient)
    {
        this.client = httpClient;
    }

    public async Task CreatePost(Post post)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("https://localhost:7295/Post", post);

        if (!responseMessage.IsSuccessStatusCode)
        {
            string result = await responseMessage.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/Post");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<Post> forum = JsonSerializer.Deserialize<ICollection<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return forum;
    }

    public async Task<Post> GetPostById(int id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/Post/{id}");
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }


}
