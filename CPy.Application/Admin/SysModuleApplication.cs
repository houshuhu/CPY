using System.Collections.Generic;
using CPy.Common.ExcuteResult;
using CPy.Core.UnitofWork;
using CPy.Domain.Repositories;
using CPy.Dto.Admin;
using CPy.IApplication.Admin;
using CPy.Model.Models.Admin;

namespace CPy.Application.Admin
{
    public class SysModuleApplication : ISysModuleApplication
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IRepository<SysModule> _sysModuleRepository;

        public SysModuleApplication(IUnitofWork unitofWork, IRepository<SysModule> sysModuleRepository)
        {
            _unitofWork = unitofWork;
            _sysModuleRepository = sysModuleRepository;
        }

        public WebExcuteResult<List<SysModuleSearchDto>> Search(SysModuleSearchParam param)
        {
            throw new System.NotImplementedException();
        }
    }
}