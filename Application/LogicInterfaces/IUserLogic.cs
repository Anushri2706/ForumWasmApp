using Domain.DTOs;
using Domain.Model;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(User user);
    public Task<User> GetAsync(int id);
    
    Task<User> ValidateUser(UserLoginDto userDto);



}