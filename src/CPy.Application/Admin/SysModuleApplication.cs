using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
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
            Expression<Func<SysModule, bool>> expression = t => !t.IsDelete;
            if (!string.IsNullOrEmpty(param.MName))
            {
                expression = expression.And(t => t.MName.Contains(param.MName));
            }
            var modules =_sysModuleRepository.GetEntities().Where(expression);
            var result = modules.CheckifNoCount<SysModule, SysModuleSearchDto>();
            if (result.ResultDate.RowsCount != 0)
            {
                var list = modules.OrderBy(t => t.MNo).PageBy(param).ToList();
                result.ResultDate.ResultList = list.MapToList<SysModule, SysModuleSearchDto>();
            }
            return result;
        }

        public WebExcuteResult<SysModuleSearchDto> GetSysModuleById(Guid id)
        {
            var module = _sysModuleRepository.GetByKey(id);
            return new WebExcuteResult<SysModuleSearchDto>(module.MapTo<SysModule, SysModuleSearchDto>());
        }

        public WebExcuteResult<EmptyResult> Save(SysModuleSaveParam param)
        {
            using (_unitofWork)
            {
                if (param.Id == Guid.Empty)
                {
                    var module = new SysModule(param.MNo, param.MName, param.Description);
                    _sysModuleRepository.Insert(module);
                }
                else
                {
                    var module = _sysModuleRepository.GetByKey(param.Id);
                    param.MapTo(module);
                }

                return _unitofWork.Commit();
            }

        }

        public WebExcuteResult<EmptyResult> Delete(List<Guid> list)
        {
            using (_unitofWork)
            {
                var modules = _sysModuleRepository.GetEntities().Where(t => list.Contains(t.Id)).ToList();
                _sysModuleRepository.SoftDelete(modules);
                return _unitofWork.Commit();
            }
        }

        public WebExcuteResult<List<SysModuleDictionaryList>> GetModuleList()
        {
            var list = _sysModuleRepository.GetEntities().OrderBy(t=>t.MNo).Select(t => new SysModuleDictionaryList()
            {
                Id = t.Id,
                MName = t.MName,
                //MNo = t.MNo
            }).ToList();
            list.Insert(0,new SysModuleDictionaryList(){Id = Guid.Empty,MName = "请选择"});
            return new WebExcuteResult<List<SysModuleDictionaryList>>(list);
        }
    }

}