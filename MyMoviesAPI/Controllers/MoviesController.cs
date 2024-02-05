using Microsoft.AspNetCore.Mvc;
using MyMoviesAPI.Models;
using MyMoviesAPI.Models.Movies;

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
    /// <param name="ascending">Whether the list should be sorted with Ascending or Descending order</param>
    /// <returns></returns>
    private IQueryable<Movie> SortMovies(IQueryable<Movie> movies, MovieSortBy? sortBy, bool ascending)
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
        if (!ascending) movies = movies.Reverse();

        return movies;
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
    public async Task<ActionResult<PaginationDto<Movie>>> GetMovies([FromQuery] int pageSize = 20, [FromQuery] int page = 1, [FromQuery] string? title = null, [FromQuery] string? genre = null, 
        [FromQuery] MovieSortBy? sortBy = null, bool ascending = false)
    {
        if (page < 1) return BadRequest($"Page {page} is an invalid input");
        if (pageSize < 1) return BadRequest($"PageSize {pageSize} is an invalid input");

        IQueryable<Movie> movies = _dbContext.Movies.AsQueryable();

        if (genre != null) movies = movies.Where(x => x.Genre.ToLower().Contains(genre.ToLower()));
        if (title != null) movies = movies.Where(x => x.Title.ToLower().Contains(title.ToLower()));

        if (sortBy != null) movies = SortMovies(movies, sortBy, ascending);

        int totalDataCount = movies.Count();

        movies = movies.Skip((page - 1) * pageSize).Take(pageSize);
        int pageCount = (totalDataCount + pageSize - 1) / pageSize;

        return Ok(new PaginationDto<Movie>(movies.ToList(), totalDataCount, page, pageCount, pageSize, page - 1, page + 1));
    }

}
