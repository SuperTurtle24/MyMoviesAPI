using MyMoviesAPI.Models.Abstract;

namespace MyMoviesAPI.Models.Interfaces;

public interface IDtoable<D> where D : Dto
{
    public D ToDto();
}
