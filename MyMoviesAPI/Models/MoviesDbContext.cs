using Microsoft.EntityFrameworkCore;
using MyMoviesAPI.Models.Movies;

namespace MyMoviesAPI.Models;
public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }
    public DbSet<Movie> Movies { get; set; }
}
