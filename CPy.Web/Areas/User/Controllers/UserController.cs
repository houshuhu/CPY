using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CPy.IApplication.User;

namespace CPy.Web.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}