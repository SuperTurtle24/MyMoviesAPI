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

    public PaginationDto(List<T> data, int totalDataCount, int page, int pageSize, int previousPage, int nextPage)
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
