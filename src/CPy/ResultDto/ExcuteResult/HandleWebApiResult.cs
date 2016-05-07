using System.Web.Mvc;

namespace CPy.ResultDto.ExcuteResult
{
    public static class HandleWebApiResult
    {
        public static JsonResult HandleResult<T>(WebExcuteResult<T> result) where T:class 
        {
            if (result.ResultType==ExcuteResultType.Error)
            {
                //TODO:记录日志
                
            }
            return new JsonResult()
            {
                Data = new { State = result.ResultType, Data = result.ResultDate }
            };
        }
    }
}