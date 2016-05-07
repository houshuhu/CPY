﻿namespace CPy.RequestDto.Pagination
{
    public class Pagination : IPagination
    {

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int SkipCount
        {
            get { return (PageNumber-1)*PageSize;}
        }
    }
}