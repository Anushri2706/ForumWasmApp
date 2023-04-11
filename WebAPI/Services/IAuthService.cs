using Domain.Model;

namespace WebAPI.Services;

public interface IAuthService
{
    Task RegisterUser(User user);
} 
