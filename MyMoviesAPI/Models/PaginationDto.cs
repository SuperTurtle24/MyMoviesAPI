namespace MyMoviesAPI.Models;
public class PaginationDto<T>
{
    public List<T> Data { get; set; }
    public int TotalDataCount { get; set; }

    public int Page { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }

    public int PreviousPage { get; set; }
    public int NextPage { get; set; }

    public PaginationDto() { }

    public PaginationDto(List<T> data, int totalDataCount, int page, int pageCount, int pageSize, int previousPage, int nextPage)
    {
        Data = data;
        TotalDataCount = totalDataCount;
        Page = page;
        PageCount = pageCount;
        PageSize = pageSize;
        PreviousPage = previousPage;
        NextPage = nextPage;
    }
}
