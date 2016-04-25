using System.Security;

namespace CPy.Common.ExcuteResult
{
    public class WebExcuteResult<T>
    {
        /// <summary>
        /// 结果
        /// </summary>
        public T ResultDate { get; set; }
        /// <summary>
        /// 结果类型：用于记录日志
        /// </summary>
        public ExcuteResultType ResultType { get; set; }

        public WebExcuteResult(ExcuteResultType resultType,T result)
        {
            ResultDate = result;
            ResultType = resultType;
        }

        public WebExcuteResult(T result, ExcuteResultType resultType = ExcuteResultType.Success)
        {
            ResultDate = result;
        }

    }
}