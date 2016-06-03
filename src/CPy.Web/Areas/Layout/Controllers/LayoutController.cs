using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPy.IApplication.Admin;
using CPy.ResultDto.ExcuteResult;

namespace CPy.Web.Areas.Layout.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ILayoutApplication _layoutApplication;

        public LayoutController(ILayoutApplication layoutApplication)
        {
            _layoutApplication = layoutApplication;
        }

        // GET: Layout/Layout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetModuleList()
        {
            return HandleWebResult.HandleResult(_layoutApplication.GetModuleList());
        }
    }
}