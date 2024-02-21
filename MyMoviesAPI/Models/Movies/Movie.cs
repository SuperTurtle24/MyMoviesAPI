using MyMoviesAPI.Models.Abstract;
using MyMoviesAPI.Models.Actors;
using MyMoviesAPI.Models.Interfaces;

namespace MyMoviesAPI.Models.Movies;
public class Movie : Entity, IDtoable<MovieDto>
{
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public int VoteCount { get; set; }
    public double VoteAverage { get; set; }
    public string OriginalLanguage { get; set; }
    public string Genre { get; set; }
    public string PosterUrl { get; set; }
    public virtual List<Actor>? Actors { get; set; }

    public Movie() { }

    public Movie(Guid id, DateTime releaseDate, string title, string overview, double popularity, int voteCount, double voteAverage, string originalLanguage, string genre, string posterUrl, List<Actor>? actors)
    {
        Id = id;
        ReleaseDate = releaseDate;
        Title = title;
        Overview = overview;
        Popularity = popularity;
        VoteCount = voteCount;
        VoteAverage = voteAverage;
        OriginalLanguage = originalLanguage;
        Genre = genre;
        PosterUrl = posterUrl;
        Actors = actors;
    }

    public MovieDto ToDto() => new(this);
}
