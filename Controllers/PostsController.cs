using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostsService _postsService;

    public PostsController(PostsService postsService) =>
        _postsService = postsService;

    [HttpGet]
    public async Task<List<Post>> Get() =>
        await _postsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Post>> Get(string id)
    {
        var post = await _postsService.GetAsync(id);

        if (post is null)
        {
            return NotFound();
        }

        return post;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] Post newPost)
    {
        await _postsService.CreateAsync(newPost);

        return CreatedAtAction(nameof(Get), new { _id = newPost._id }, newPost);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update( string id,
    [FromForm] Post updatedPost)
    {
        var post = await _postsService.GetAsync(id);

        if (post is null)
        {
            return NotFound();
        }

        updatedPost._id = post._id;

        await _postsService.UpdateAsync(id, updatedPost);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var post = await _postsService.GetAsync(id);

        if (post is null)
        {
            return NotFound();
        }

        await _postsService.RemoveAsync(id);

        return NoContent();
    }
}