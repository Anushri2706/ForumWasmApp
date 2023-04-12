using Domain;
using Domain.Model;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreatePostAsync(Post dto);
    Task<Post?> GetPostById(int id);
    Task<IEnumerable<Post>> GetAllPostsAsync(Post post);
}