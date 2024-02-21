namespace MyMoviesAPI.Models.Abstract
{
    public abstract class Dto
    {
        public Guid Id { get; set; }

        public Dto() { }

        public Dto(Guid id) { Id = id; }
    }
}
