namespace CPy.RequestDto.Pagination
{
    public interface IPagination
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int SkipCount { get; }
    }
}