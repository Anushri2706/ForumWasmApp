using Domain.DTOs;
using Domain.Model;

namespace HttpsClients.ClientInterfaces;

public interface IPostService
{
    Task CreatePost(Post post);
    Task<IEnumerable<Post>> GetPosts();
    Task<Post> GetPostById(int Id);

}