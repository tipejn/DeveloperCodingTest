using HackerNewsBestStories.Api.HackerRankApi.Contract;
using HackerNewsBestStories.Api.HackerRankApi.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsBestStories.Api.HackerRankApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryController(
    IMediator mediator, 
    ILogger<StoryController> logger) 
    : ControllerBase
{
    /// <summary>
    /// Retrieves the top n stories from Hacker News.
    /// </summary>
    /// <param name="count">The number of top stories to retrieve (default: 10).</param>
    /// <returns>An array of story objects.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<StoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTopStories([FromQuery] int count = 10)
    {
        try
        {
            if (count < 1)
            {
                return BadRequest("Count must be greater than 0");
            }
            var query = new GetBestStoriesQuery(count);
            var stories = await mediator.Send(query);
            return Ok(stories);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}