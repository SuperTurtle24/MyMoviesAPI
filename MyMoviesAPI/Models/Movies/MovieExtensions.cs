namespace MyMoviesAPI.Models.Movies;
public static class MovieExtensions
{
    public static IQueryable<Movie> FilterMovies(this IQueryable<Movie> movies, string? genre = null, string? title = null)
    {
        if (genre != null) movies = movies.Where(x => x.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
        if (title != null) movies = movies.Where(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        return movies;
    }
}
