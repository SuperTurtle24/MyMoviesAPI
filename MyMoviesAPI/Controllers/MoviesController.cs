using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyMoviesAPI.Models;
using MyMoviesAPI.Models.Actors;
using MyMoviesAPI.Models.Movies;
using System.Runtime.CompilerServices;

namespace MyMoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MoviesDbContext _dbContext;

    public MoviesController(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Sorts a List of Movies using a MovieSortBy Enum
    /// </summary>
    /// <param name="movies">The List of Movies to be sorted</param>
    /// <param name="sortBy">The Enum Representing how the list should be sorted</param>
    /// <param name="descending">Whether the list should be sorted with Ascending or Descending order</param>
    /// <returns></returns>
    private IQueryable<Movie> SortMovies(IQueryable<Movie> movies, MovieSortBy? sortBy, bool descending)
    {
        switch (sortBy)
        {
            case MovieSortBy.Title:
                movies = movies.OrderBy(x => x.Title);
                break;
            case MovieSortBy.ReleaseDate:
                movies = movies.OrderBy(x => x.ReleaseDate);
                break;
            case MovieSortBy.Popularity:
                movies = movies.OrderBy(x => x.Popularity);
                break;
            case MovieSortBy.VoteCount:
                movies = movies.OrderBy(x => x.VoteCount);
                break;
            case MovieSortBy.VoteAverage:
                movies = movies.OrderBy(x => x.VoteAverage);
                break;
        }
        if (!descending) movies = movies.Reverse();

        return movies;
    }

    /// <summary>
    /// Search for all Movies
    /// </summary>
    /// <param name="pageSize">How many Movies per page</param>
    /// <param name="page">The Page Number</param>
    /// <param name="title">Filter by Movie Title</param>
    /// <param name="genre">Filter by Genre</param>
    [HttpGet("")]
    public async Task<ActionResult<PaginationDto<MovieDto>>> GetMovies([FromQuery] int pageSize = 20, [FromQuery] int page = 1, [FromQuery] string? title = null, [FromQuery] string? genre = null,
        [FromQuery] Guid? actorId = null, [FromQuery] MovieSortBy? sortBy = null, bool descending = true)
    {
        if (page < 1) return BadRequest($"Page {page} is an invalid input");
        if (pageSize < 1) return BadRequest($"PageSize {pageSize} is an invalid input");

        IQueryable<Movie> movies = _dbContext.Movies.Include(x => x.Actors).FilterMovies(genre, title, actorId);
        if (sortBy != null) movies = SortMovies(movies, sortBy, descending);

        movies = movies.Skip((page - 1) * pageSize).Take(pageSize);

        return Ok(new PaginationDto<MovieDto>(await movies.Select(x => x.ToDto()).ToListAsync(), page, pageSize, page - 1, page + 1));
    }

    /// <summary>
    /// Add an Actor to a Movie
    /// </summary>
    /// <param name="movieId">The Id of the Movie</param>
    /// <param name="actorId">The Id of the Actor</param>
    [HttpPost("addActor")]
    public async Task<ActionResult<MovieDto>> AddActor([FromQuery] Guid movieId, [FromQuery] Guid actorId)
    {
        Actor? actor = await _dbContext.Actors.FindAsync(actorId);
        if (actor == null) return NotFound($"Cannot find Actor with the Id: {actorId}");
        
        Movie? movie = await _dbContext.Movies.FindAsync(movieId);
        if (movie == null) return NotFound($"Cannot find Movie with the Id: {movieId}");

        if (movie.Actors == null) movie.Actors = new();
        movie.Actors.Add(actor);
        
        await _dbContext.SaveChangesAsync();
        return Ok(movie.ToDto());
    }
}
