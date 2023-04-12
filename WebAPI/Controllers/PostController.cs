using Application.LogicInterfaces;

using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController:ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] Post dto)
    {
        try
        {
            Post created = await postLogic.CreatePostAsync(dto);
            return Created($"/Post/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]//GET requests to this controller ends here
    //FromQuery to indicate that this argument should be extracted from the query parameters of the URI.
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? title,string? description)
    {
        try
        {
            Post post = new(title,description);
            IEnumerable<Post> posts = await postLogic.GetAllPostsAsync(post);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{forumId:int}")]
    public async Task<ActionResult<Post>> GetPostById([FromRoute] int Id)
    {
        try
        {
            Post dto = await postLogic.GetByIdAsync(Id);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}