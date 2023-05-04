using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Post
{
    [Key]
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(User owner, string title, string body)
    {
<<<<<<< Updated upstream
        Owner = owner;
=======
>>>>>>> Stashed changes
        Body = body;
        Title = title;
    }
}