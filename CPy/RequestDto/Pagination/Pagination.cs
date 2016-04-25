namespace CPy.RequestDto.Pagination
{
    public class Pagination : IPagination
    {

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int SkipCount
        {
            get { return (PageIndex-1)*PageSize;}
        }
    }
}