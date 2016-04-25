using System.Collections.Generic;
using CPy.Dto.Admin;
using CPy.ResultDto.ExcuteResult;
using CPy.ResultDto.Pagination;

namespace CPy.IApplication.Admin
{
    public interface ISysModuleApplication
    {
        WebExcuteResult<PagedResultOutPut<SysModuleSearchDto>> Search(SysModuleSearchParam param);
    }
}