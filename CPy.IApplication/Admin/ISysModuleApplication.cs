using System.Collections.Generic;
using CPy.Common.ExcuteResult;
using CPy.Dto.Admin;

namespace CPy.IApplication.Admin
{
    public interface ISysModuleApplication
    {
        WebExcuteResult<List<SysModuleSearchDto>> Search(SysModuleSearchParam param);
    }
}