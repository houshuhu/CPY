using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CPy.IApplication.User;

namespace CPy.Web.Areas.User.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public void Save()
        {
            _userApplication.Save();
        }
    }
}