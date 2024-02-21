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
    /// Search for all Movies
    /// </summary>
    /// <param name="pageSize">How many Movies per page</param>
    /// <param name="page">The Page Number</param>
    /// <param name="title">Filter by Movie Title</param>
    /// <param name="genre">Filter by Genre</param>
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
}
