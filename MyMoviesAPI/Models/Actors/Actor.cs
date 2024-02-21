using MyMoviesAPI.Models.Abstract;
using MyMoviesAPI.Models.Movies;

namespace MyMoviesAPI.Models.Actors;
public class Actor : Entity
{
    public string Name { get; set; }
    public List<Movie>? Movies { get; set; }

    public Actor() { }
    public Actor(string name,  List<Movie>? movies)
    {
        Name = name;
        Movies = movies;
    }
}
