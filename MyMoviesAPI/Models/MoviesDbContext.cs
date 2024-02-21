using Microsoft.EntityFrameworkCore;
using MyMoviesAPI.Models.Actors;
using MyMoviesAPI.Models.Movies;

namespace MyMoviesAPI.Models;
public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasMany(movie => movie.Actors).WithMany(actors => actors.Movies);
    }
}
