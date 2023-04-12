using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.Model;

namespace Application.LogicImpl;

public class PostLogic : IPostLogic
{

    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }

    public async Task<Post> CreatePostAsync(Post dto)
    {
        ValidatePost(dto);
        Post post = new Post(dto.Title, dto.Body);
        Post created = await postDao.CreatePostAsync(post);
        return created;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync(Post post)
    {
        IEnumerable<Post> posts = await postDao.GetAllPostsAsync(post);
        return posts;
    }
    
    public async Task<Post> GetByIdAsync(int Id)
    {
        Post? post=  await postDao.GetPostById(Id);
        if (post == null)
        {
            throw new Exception($"Post with {Id} was not found");
        }
        
        return post;
    }

    

    private void ValidatePost(Post post)
    {
        if (string.IsNullOrEmpty(post.Title)) throw new Exception("Title cannot be empty");
        if (string.IsNullOrEmpty(post.Body)) throw new Exception("Description cannot be empty");
    }
}