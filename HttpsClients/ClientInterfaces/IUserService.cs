using System.Security.Claims;
using Domain.DTOs;
using Domain.Model;

namespace HttpsClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
    
  


}