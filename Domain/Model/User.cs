namespace Domain.Model;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
<<<<<<< Updated upstream
=======
    
    public string password { get; set; }
    // public ICollection<Post> Posts { get; set; }


    public User(string userName, string password)
    {
        this.UserName = userName;
        this.password = password;
    }
    
>>>>>>> Stashed changes
}