using System.Collections.Generic;
using CPy.Dto.Admin;
using CPy.ResultDto.ExcuteResult;

namespace CPy.IApplication.Admin
{
    public interface ILayoutApplication
    {
        WebExcuteResult<List<LayoutResponseDto>> GetModuleList();
    }
}