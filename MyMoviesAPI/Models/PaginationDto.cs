using MyMoviesAPI.Models.Abstract;

namespace MyMoviesAPI.Models;
public class PaginationDto<D> where D : Dto
{
    public List<D> Data { get; set; }
    public int TotalDataCount { get; set; }

    public int Page { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }

    public int PreviousPage { get; set; }
    public int NextPage { get; set; }

    public PaginationDto() { }

    public PaginationDto(List<D> data, int page, int pageSize, int previousPage, int nextPage)
    {
        Data = data;
        TotalDataCount = data.Count;
        Page = page;
        PageSize = pageSize;
        PageCount = (TotalDataCount + PageSize - 1) / PageSize;
        PreviousPage = previousPage;
        NextPage = nextPage;
    }
}
