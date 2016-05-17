using System;
using System.Web.Mvc;
using CPy.Dto.Admin;
using CPy.IApplication.Admin;
using CPy.ModelBinder;
using CPy.ResultDto.ExcuteResult;
using CPy.Web.Controllers;

namespace CPy.Web.Areas.Admin.Controllers
{
    public class SysFunctionController:BaseController
    {
        private readonly ISysFunctionApplication _sysFunctionApplication;

        public SysFunctionController(ISysFunctionApplication sysFunctionApplication)
        {
            _sysFunctionApplication = sysFunctionApplication;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InitDataGrid([ModelBinder(typeof(BaseModelBinder<SysFunctionSearchParam>))] SysFunctionSearchParam param)
        {
            var result = HandleWebResult.HandleResult(_sysFunctionApplication.InitDataGrid(param));
            return HandleWebResult.HandleResult(_sysFunctionApplication.InitDataGrid(param));
        }

        public JsonResult InitDetail(Guid id)
        {
            return HandleWebResult.HandleResult(_sysFunctionApplication.InitDetail(id));
        }

        [HttpPost]
        public JsonResult Add([ModelBinder(typeof(BaseModelBinder<SysFunctionAddParam>))]SysFunctionAddParam param)
        {
            return HandleWebResult.HandleResult(_sysFunctionApplication.Add(param));
        }
    }
}