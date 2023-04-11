namespace Domain.DTOs;

public class UserLoginDto
{
    public UserLoginDto(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; init; }
    public string Password { get; init; }
}