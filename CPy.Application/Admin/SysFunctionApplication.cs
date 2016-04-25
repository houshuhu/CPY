using CPy.Core.UnitofWork;
using CPy.Domain.Repositories;
using CPy.IApplication.Admin;
using CPy.Model.Models.Admin;

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
    }
}