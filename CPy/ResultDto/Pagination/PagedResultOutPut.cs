using System.Collections.Generic;

namespace CPy.ResultDto.Pagination
{
    public class PagedResultOutPut<T>
    {
        public IReadOnlyList<T> ResultList { get; set; }
        public int RowsCount { get; set; }

        public PagedResultOutPut()
        {
        }

        public PagedResultOutPut(IReadOnlyList<T> resultList,int rowsCount)
        {
            ResultList = resultList;
            RowsCount = rowsCount;
        }
    }
}