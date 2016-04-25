using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CPy.Core.UnitofWork;
using CPy.Domain.Repositories;
using CPy.Dto.Admin;
using CPy.IApplication.Admin;
using CPy.Linq.Extensions;
using CPy.Model.Models.Admin;
using CPy.ResultDto.ExcuteResult;
using CPy.ResultDto.Pagination;

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

        public WebExcuteResult<PagedResultOutPut<SysModuleSearchDto>> Search(SysModuleSearchParam param)
        {
            Expression<Func<SysModule, bool>> expression = t => true;
            if (!string.IsNullOrEmpty(param.ModuleName))
            {
                expression = expression.And(t => t.MName.Contains(param.ModuleName));
            }
            IQueryable<SysModule> modules =
                _sysModuleRepository.GetEntities().Where(expression).OrderBy(t => t.MNo).PageBy(param);
            var result = modules.CheckifNoCount<SysModule, SysModuleSearchDto>();
            if (result.ResultDate.RowsCount!=0)
            {
                
            }
            return result;
        }
    }
}