using System.Web.Mvc;
using CPy.ResultDto.Pagination;

namespace CPy.ResultDto.ExcuteResult
{
    public static class HandleWebResult
    {
        public static JsonResult HandleResult<T>(WebExcuteResult<PagedResultOutPut<T>> result) where T : class 
        {
            if (result.ResultType == ExcuteResultType.Error)
            {
                //TODO:记录日志

            }
            return new JsonResult()
            {
                Data = new {rows = result.ResultDate.ResultList,total=result.ResultDate.RowsCount }
            };
        }
        public static JsonResult HandleResult<T>(WebExcuteResult<T> result) where T:class 
        {
            if (result.ResultType == ExcuteResultType.Error)
            {
                //TODO:记录日志

            }
            return new JsonResult()
            {
                Data = new { ExceptionMessage=result.ExceptionMessage,ResultType=result.ResultType,ResultData=result.ResultDate }
            };
        }
    }
}