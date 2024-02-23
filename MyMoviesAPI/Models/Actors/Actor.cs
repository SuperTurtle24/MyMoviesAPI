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
    
    public Actor(CreateActorDto createActorDto)
    {
        Name = createActorDto.Name;
    }

    public SimpleActorDto ToDto() => new(this);
}

public class CreateActorDto
{
    public string Name { get; set; }
    public CreateActorDto() { }
}
