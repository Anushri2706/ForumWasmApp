using Application.DAOInterfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;
    public async Task<Post> CreatePostAsync(Post dto)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(dto);
        await context.SaveChangesAsync();
        return added.Entity;    }

    public async Task<Post?> GetPostById(int id)
    {
        Post? found = await context.Posts
            .SingleOrDefaultAsync(post => post.Id == id);
        return found;
        
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync(Post post)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Id).AsQueryable();
        if (post.Title!=null)
        {
            query = query.Where(u =>
                u.Title.Contains(post.Title, StringComparison.OrdinalIgnoreCase) & u.Body.Contains(post.Body));
        }

        List<Post> result = await query.ToListAsync();

        return result;
    }    
}

