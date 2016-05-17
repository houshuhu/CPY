using System;
using System.Linq;
using System.Web.Mvc;
using CPy.Dto.Admin;
using CPy.IApplication.Admin;
using CPy.Log;
using CPy.ModelBinder;
using CPy.ResultDto.ExcuteResult;
using CPy.Web.Controllers;
using WebGrease.Css.Extensions;

namespace CPy.Web.Areas.Admin.Controllers
{
    public class SysModuleController : BaseController
    {
        private readonly ISysModuleApplication _sysModuleApplication;

        public SysModuleController(ISysModuleApplication sysModuleApplication)
        {
            _sysModuleApplication = sysModuleApplication;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SysModuleDetail()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InitGrid([ModelBinder(typeof(BaseModelBinder<SysModuleSearchParam>))]SysModuleSearchParam param)
        {
            LogHelper.Info("datefafafajfajfioajf");
            LogHelper.Error("this is error");
            var result = _sysModuleApplication.Search(param);
            var a = HandleWebResult.HandleResult(result);
            return a;
        }

        [HttpPost]
        public JsonResult InitDetail(Guid id)
        {
            return HandleWebResult.HandleResult(_sysModuleApplication.GetSysModuleById(id));
        }

        [HttpPost]
        public JsonResult Save(SysModuleSaveParam param)
        {
            return HandleWebResult.HandleResult(_sysModuleApplication.Save(param));
        }

        [HttpPost]
        public JsonResult Delete([ModelBinder(typeof(BaseModelBinder<SysModuleDeleteDto>))]SysModuleDeleteDto dto)
        {
            return HandleWebResult.HandleResult(_sysModuleApplication.Delete(dto.List));
        }

        [HttpGet]
        public JsonResult GetModuleList()
        {
            var dic = _sysModuleApplication.GetModuleList();

            return HandleWebResult.HandleDictionary(dic);
        }
    }
}