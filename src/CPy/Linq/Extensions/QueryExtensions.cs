using System.Collections.Generic;
using System.Linq;
using CPy.RequestDto.Pagination;
using CPy.ResultDto.ExcuteResult;
using CPy.ResultDto.Pagination;

namespace CPy.Linq.Extensions
{
    public static class QueryExtensions
    {
        /// <summary>
        /// 分页取值
        /// </summary>
        /// <typeparam name="TEnity">实体类Type</typeparam>
        /// <param name="queryable">实体类集合</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="skipCount">跳页条数</param>
        /// <returns></returns>
        public static IQueryable<TEnity> PageBy<TEnity>(this IQueryable<TEnity> queryable, int pageSize, int skipCount)
        {
            return queryable.Skip(skipCount).Take(pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pagination">IPagination类型</param>
        /// <returns></returns>
        public static IQueryable<TEnity> PageBy<TEnity>(this IQueryable<TEnity> queryable, IPagination pagination)
        {
            return queryable.PageBy(pagination.PageSize, pagination.SkipCount);
        }

        /// <summary>
        /// 检验列表是否为空
        /// </summary>
        /// <typeparam name="TEnity">实体类</typeparam>
        /// <typeparam name="TDto">数据传输对象</typeparam>
        /// <param name="queryable"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static WebExcuteResult<PagedResultOutPut<TDto>> CheckifNoCount<TEnity, TDto>(this IQueryable<TEnity> queryable)
        {
            var count = queryable.Count();
            if (count==0)
            {
                return new WebExcuteResult<PagedResultOutPut<TDto>>(ExcuteResultType.SuccessNoDate, new PagedResultOutPut<TDto>(new List<TDto>(), count));
            }
            else
            {
                return new WebExcuteResult<PagedResultOutPut<TDto>>(ExcuteResultType.Success, new PagedResultOutPut<TDto>(new List<TDto>(), count));
            }
        }
    }
}