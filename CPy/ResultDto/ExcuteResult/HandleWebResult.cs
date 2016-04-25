using System.Web.Mvc;

namespace CPy.ResultDto.ExcuteResult
{
    public static class HandleWebResult
    {
        public static JsonResult HandleResult<T>(WebExcuteResult<T> result)
        {
            if (result.ResultType==ExcuteResultType.Error)
            {
                //TODO:记录日志
                
            }
            return new JsonResult()
            {
                Data = new { State=result.ResultType,OutPut=result.ResultDate}
            };
        }
    }
}