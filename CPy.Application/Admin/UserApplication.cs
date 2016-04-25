using System;
using CPy.Core.UnitofWork;
using CPy.Domain.Repositories;
using CPy.IApplication.Admin;
using CPy.Model.Models.Admin;

namespace CPy.Application.Admin
{
    public class UserApplication:IUserApplication
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IRepository<SysUser> _userRepository;

        public UserApplication(IUnitofWork unitofWork,IRepository<SysUser> userRepository)
        {
            _unitofWork = unitofWork;
            _userRepository = userRepository;
        }

        public void Save()
        {
            using (_unitofWork)
            {
                var user = new SysUser()
                {
                    Id = Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    IsDelete = false,
                };
                _userRepository.Insert(user);
                _unitofWork.Commit();
            }
        }
    }
}