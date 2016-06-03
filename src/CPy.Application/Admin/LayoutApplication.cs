using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CPy.AutoMapper;
using CPy.Domain.Repositories;
using CPy.Dto.Admin;
using CPy.IApplication.Admin;
using CPy.Model.Models.Admin;
using CPy.ResultDto.ExcuteResult;

namespace CPy.Application.Admin
{
    public class LayoutApplication : ILayoutApplication
    {
        private readonly IRepository<SysModule> _sysModuleRepository;

        public LayoutApplication(IRepository<SysModule> sysModuleRepository)
        {
            _sysModuleRepository = sysModuleRepository;
        }

        public WebExcuteResult<List<LayoutResponseDto>> GetModuleList()
        {
            var list = _sysModuleRepository.GetEntities().OrderBy(t => t.MNo).ToList();
            var result=list.MapToList<SysModule,LayoutResponseDto>(new MapperConfiguration(t =>
            {
                t.CreateMap<SysModule, LayoutResponseDto>();
                t.CreateMap<SysFunction, LayoutResponseDto.FunctionData>();
            }));
            return new WebExcuteResult<List<LayoutResponseDto>>(result);
        }
    }
}