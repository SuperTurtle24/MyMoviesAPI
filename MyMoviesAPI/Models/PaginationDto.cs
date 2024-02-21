using MyMoviesAPI.Models.Abstract;

namespace MyMoviesAPI.Models;
public class PaginationDto<E> where E : Entity
{
    public List<E> Data { get; set; }
    public int TotalDataCount { get; set; }

    public int Page { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }

    public int PreviousPage { get; set; }
    public int NextPage { get; set; }

    public PaginationDto() { }

    public PaginationDto(List<E> data, int totalDataCount, int page, int pageSize, int previousPage, int nextPage)
    {
        Data = data;
        TotalDataCount = totalDataCount;
        Page = page;
        PageSize = pageSize;
        PageCount = (TotalDataCount + PageSize - 1) / PageSize;
        PreviousPage = previousPage;
        NextPage = nextPage;
    }
}
