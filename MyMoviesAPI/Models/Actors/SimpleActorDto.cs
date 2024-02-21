using MyMoviesAPI.Models.Abstract;

namespace MyMoviesAPI.Models.Actors;

public class SimpleActorDto : Dto
{
    public string Name { get; set; }

    public SimpleActorDto() { }
    public SimpleActorDto(Actor actor) : base(actor.Id)
    {
        Name = actor.Name;
    }
}
