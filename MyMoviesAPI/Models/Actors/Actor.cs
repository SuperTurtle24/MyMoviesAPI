using MyMoviesAPI.Models.Abstract;
using MyMoviesAPI.Models.Interfaces;
using MyMoviesAPI.Models.Movies;

namespace MyMoviesAPI.Models.Actors;
public class Actor : Entity, IDtoable<SimpleActorDto>
{
    public string Name { get; set; }
    public virtual List<Movie>? Movies { get; set; }

    public Actor() { }
    public Actor(string name,  List<Movie>? movies)
    {
        Name = name;
        Movies = movies;
    }

    public SimpleActorDto ToDto() => new(this);
}
