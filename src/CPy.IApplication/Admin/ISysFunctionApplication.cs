
using System;
using CPy.Dto.Admin;
using CPy.ResultDto.ExcuteResult;
using CPy.ResultDto.Pagination;

namespace CPy.IApplication.Admin
{
    public interface ISysFunctionApplication
    {
        WebExcuteResult<PagedResultOutPut<SysFunctionDto>> InitDataGrid(SysFunctionSearchParam param);

        WebExcuteResult<SysFunctionDetail> InitDetail(Guid id);
        WebExcuteResult<EmptyResult> Add(SysFunctionAddParam param);
    }
}