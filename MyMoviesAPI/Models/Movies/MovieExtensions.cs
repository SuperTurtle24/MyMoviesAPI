namespace MyMoviesAPI.Models.Movies;
public static class MovieExtensions
{
    public static IQueryable<Movie> FilterMovies(this IQueryable<Movie> movies, string? genre, string? title)
    {
        if (genre != null) movies = movies.Where(x => x.Genre.ToLower().Contains(genre.ToLower()));
        if (title != null) movies = movies.Where(x => x.Title.ToLower().Contains(title.ToLower()));
        return movies;
    }
}
