using Domain.DTOs;
using Domain.Model;

namespace HttpsClients.ClientInterfaces;

public interface IPostService
{
    Task CreateForum(Post forum);
    Task<IEnumerable<Post>> GetForums();
    Task<Post> GetForumById(int forumId);

}