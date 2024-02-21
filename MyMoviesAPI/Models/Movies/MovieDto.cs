using MyMoviesAPI.Models.Abstract;
using MyMoviesAPI.Models.Actors;

namespace MyMoviesAPI.Models.Movies;

public class MovieDto : Dto
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
    public List<SimpleActorDto>? Actors { get; set; }

    public MovieDto() { }
    public MovieDto(Movie movie) : base(movie.Id)
    {
        Title = movie.Title;
        Overview = movie.Overview;
        Popularity = movie.Popularity;
        VoteCount = movie.VoteCount;
        VoteAverage = movie.VoteAverage;
        OriginalLanguage = movie.OriginalLanguage;
        Genre = movie.Genre;
        PosterUrl = movie.PosterUrl;
        Actors = movie.Actors?.Select(x => x.ToDto()).ToList() ?? null;
    }
}
