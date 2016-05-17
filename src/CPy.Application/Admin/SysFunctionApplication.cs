using System;
using System.Linq;
using System.Linq.Expressions;
using CPy.AutoMapper;
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
    public class SysFunctionApplication : ISysFunctionApplication
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IRepository<SysFunction> _sysFunctionRepository;

        public SysFunctionApplication(IRepository<SysFunction> sysFunctionRepository, IUnitofWork unitofWork)
        {
            _sysFunctionRepository = sysFunctionRepository;
            _unitofWork = unitofWork;
        }

        public WebExcuteResult<PagedResultOutPut<SysFunctionDto>> InitDataGrid(SysFunctionSearchParam param)
        {
            Expression<Func<SysFunction, bool>> expression = t => !t.IsDelete;
            if (!string.IsNullOrEmpty(param.FunctionName))
            {
                expression = expression.And(t => t.FName.Contains(param.FunctionName));
            }
            if (param.ModuleId!=Guid.Empty)
            {
                expression = expression.And(t => t.SysModuleId == param.ModuleId);
            }
            var functions = _sysFunctionRepository.GetEntities().Where(expression);
            var result = functions.CheckifNoCount<SysFunction, SysFunctionDto>();
            if (result.ResultDate.RowsCount > 0)
            {
                var list = functions.OrderBy(t => t.FNo).PageBy(param).ToList();
                result.ResultDate.ResultList = list.MapToList<SysFunction, SysFunctionDto>();
            }
            return result;
        }

        public WebExcuteResult<SysFunctionDetail> InitDetail(Guid id)
        {
            var function = _sysFunctionRepository.GetByKey(id);
            var result = function.MapTo<SysFunction, SysFunctionDetail>();
            return new WebExcuteResult<SysFunctionDetail>(result);
        }

        public WebExcuteResult<EmptyResult> Add(SysFunctionAddParam param)
        {
            using (_unitofWork)
            {
                var function = new SysFunction();
                if (param.Id!=Guid.Empty)
                {
                    function = _sysFunctionRepository.GetByKey(param.Id);
                }
                function=param.MapTo(function);
                _sysFunctionRepository.Insert(function);
                return _unitofWork.Commit();
            }
        }
    }
}