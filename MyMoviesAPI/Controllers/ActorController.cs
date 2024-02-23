using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMoviesAPI.Models;
using MyMoviesAPI.Models.Actors;
using MyMoviesAPI.Models.Movies;

namespace MyMoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorController : ControllerBase
{
    private readonly MoviesDbContext _dbContext;

    public ActorController(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Search for all Actors
    /// </summary>
    /// <param name="pageSize">How many Actors per page</param>
    /// <param name="page">The Page Number</param>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<PaginationDto<SimpleActorDto>>> GetActors([FromQuery] int pageSize = 20, [FromQuery] int page = 1)
    {
        if (page < 1) return BadRequest($"Page {page} is an invalid input");
        if (pageSize < 1) return BadRequest($"PageSize {pageSize} is an invalid input");

        IQueryable<Actor> actors = _dbContext.Actors;

        actors = actors.Skip((page - 1) * pageSize).Take(pageSize);

        return Ok(new PaginationDto<SimpleActorDto>(await actors.Select(x => x.ToDto()).ToListAsync(), page, pageSize, page - 1, page + 1));
    }

    /// <summary>
    /// Create an Actor
    /// </summary>
    /// <param name="createActorDto"></param>
    /// <returns></returns>
    [HttpPut("create")]
    public async Task<ActionResult<SimpleActorDto>> CreateActor([FromBody] CreateActorDto createActorDto)
    {
        Actor actor = new(createActorDto);

        await _dbContext.Actors.AddAsync(actor);
        await _dbContext.SaveChangesAsync();

        return Ok(actor.ToDto());
    }
}
