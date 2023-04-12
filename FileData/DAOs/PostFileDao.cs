using Application.DAOInterfaces;
using Domain;
using Domain.Model;

namespace FileData.DAOs;

public class PostFileDao: IPostDao
{

    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreatePostAsync(Post dto)
    {
        
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(f => f.Id);
            id++;
        }
        dto.Id = id;
        
        context.SaveChanges();

        return Task.FromResult(dto);
    }

    public Task<Post?> GetPostById(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetAllPostsAsync(Post post)
    {
        IEnumerable<Post> forums = context.Posts.AsEnumerable();
        if (post.Title!=null)
        {
            forums = context.Posts.Where(u =>
                u.Title.Contains(post.Title, StringComparison.OrdinalIgnoreCase) & u.Body.Contains(post.Body));
        }

        return Task.FromResult(forums);
    }
}