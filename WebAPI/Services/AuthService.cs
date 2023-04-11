using System.ComponentModel.DataAnnotations;
using Domain.Model;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IList<User> users = new List<User>
    {
        new User
        {
          
          UserName = "Anushri Gupta",
          Id = 3,
          password = "CoolKids"
        },
        new User
        {
            UserName = "Hello Hi",
            Id = 4,
            password = "CoolKids12"
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

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
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
}
