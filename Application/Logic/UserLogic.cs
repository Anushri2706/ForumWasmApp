using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Model;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(User user)
    {
        User? existing = await userDao.GetByUsername(user.UserName, user.password);
        if (existing != null)
            throw new Exception("Username already taken!");
        ValidateData(user);
        User toCreate = new User(user.UserName, user.password);
        
        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    public async Task<User> GetAsync(int id)
    {
        User? userById = await userDao.GetByIdAsync(id);
        if (userById == null)
        {
            throw new Exception($"User with {id} was not found");
        }

        return userById;
    }

    private static void ValidateData(User userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters");
        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters");
        if ( password.Length<4)
            throw new Exception("Password must atleast of 5 characters");
    }
    
    public async Task<User> ValidateUser(UserLoginDto dto)
    {
        IEnumerable<User?> users = await userDao.getAllUsersAsync();
            User? existingUser = users.FirstOrDefault(u => 
            u.UserName.Equals( dto.Username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.password.Equals(dto.Password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
    
}