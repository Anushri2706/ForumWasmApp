using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Domain.Model;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserDao userDao;
    
    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        userDao.CreateAsync(user);
        
        return Task.CompletedTask;
    }
}
