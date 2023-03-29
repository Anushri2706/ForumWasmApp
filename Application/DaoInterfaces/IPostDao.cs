using Domain.DTOs;
using Domain.Model;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task<Post> GetByIdAsync(int id);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);

}