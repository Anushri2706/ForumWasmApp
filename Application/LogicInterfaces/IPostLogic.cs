using Domain;
using Domain.Model;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreatePostAsync(Post dto);
    Task<IEnumerable<Post>> GetAllPostsAsync(Post dto);
    Task<Post> GetByIdAsync(int id);
}