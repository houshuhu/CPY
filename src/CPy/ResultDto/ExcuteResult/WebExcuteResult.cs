using System;
using System.Runtime.Serialization;
using System.Security;

namespace CPy.ResultDto.ExcuteResult
{
    public class WebExcuteResult<T> where T:class 
    {
        /// <summary>
        /// 结果
        /// </summary>
        public T ResultDate { get; set; }
        /// <summary>
        /// 结果类型：用于记录日志
        /// </summary>
        public ExcuteResultType ResultType { get; set; }

        public string ExceptionMessage { get; set; }

        public WebExcuteResult()
        {
            ResultType = ExcuteResultType.Success;
        }

        public WebExcuteResult(ExcuteResultType resultType,T result)
        {
            ResultDate = result;
            ResultType = resultType;
        }

        public WebExcuteResult(T result, ExcuteResultType resultType = ExcuteResultType.Success)
        {
            ResultDate = result;
        }

        public WebExcuteResult(string exceptionMessage, ExcuteResultType resultType = ExcuteResultType.Error)
        {
            ExceptionMessage = exceptionMessage;
        }

    }
}