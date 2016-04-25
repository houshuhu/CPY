namespace CPy.RequestDto.Pagination
{
    public interface IPagination
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int SkipCount { get;}
    }
}