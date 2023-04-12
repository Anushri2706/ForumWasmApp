namespace Domain.Model;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post( string title, string body)
    {
       ;
        Body = body;
        Title = title;
    }
}