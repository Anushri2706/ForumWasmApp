using Domain.DTOs;
using Domain.Model;

namespace HttpsClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(PostCreationDto dto);
    
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId,
        string? titleContains
    );
    
    Task UpdateAsync(PostUpdateDto dto);

    Task<PostBasicDto> GetByIdAsync(int id);

    Task DeleteAsync(int id);

}