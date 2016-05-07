using System;
using System.Collections.Generic;
using NUnit.Framework;
using UDataCore.Uow;
using UDomain.Models;
using UService.Repositories;

namespace UService.Test
{
    public class UserTest : IUserTest
    {
        private readonly IUow _uow;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public UserTest(IUow uow, IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _uow = uow;
        }

        public void Save()
        {
            var a = _uow.GetHashCode();
            var b = _roleRepository.GetHashCode();
            var c = _userRepository.GetHashCode();
            using (_uow)
            {
                //var a = _roleRepository.GetByKey(21);
                var role = new Role()
                {
                    Code = "001",
                    Name = "role001"
                };
                var rolelist = new List<Role>()
                {
                    new Role()
                    {
                        Code = "003",
                        Name = "role001"
                    },
                    new Role()
                    {
                        Code = "004",
                        Name = "role001"
                    }
                };
                var user = new User()
                {
                    Code = "003",
                    Name = "user003",
                    RoleId = 22
                };
                //throw new Exception("this is a excepetion!!");
                _roleRepository.Save();
                _userRepository.Save();
                _uow.Commit();

            }


        }

        public void Save1()
        {

        }
    }
}