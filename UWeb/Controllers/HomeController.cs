using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UDataCore;
using UDomain.Models;
using UService.Repositories;
using UService.Test;

namespace UWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public void Add()
        {
            var userservice=IocContext.WindsorContainer.Resolve<IUserTest>();
            userservice.Save();
        }
    }
}
