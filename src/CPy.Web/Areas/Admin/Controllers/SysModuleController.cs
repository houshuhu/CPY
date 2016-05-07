using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;
using CPy.Dto.Admin;
using CPy.IApplication.Admin;
using CPy.ModelBinder;
using CPy.RequestDto.Pagination;
using CPy.ResultDto.ExcuteResult;
using CPy.Web.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            //var form = Request.Form;
            //var param1 = Request.Params;
            //int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            //int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            //var name = Request["MName"];
            //param.PageNumber = pageIndex;
            //param.PageSize = pageSize;
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
    }

    public class SysModuleDeleteDto
    {
        public List<Guid> List { get; set; }
    }

    public class InitGridBinder : BaseModelBinder<SysModuleSearchParam>
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //var jso1n = controllerContext.HttpContext.Request.Form[bindingContext.ModelName] as string; 
            //StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
            //string json = reader.ReadToEnd();

            //if (string.IsNullOrEmpty(json))
            //    return json;

            //JObject jsonBody = JObject.Parse(json);
            //JsonSerializer js = new JsonSerializer();
            //object obj = js.Deserialize(jsonBody.CreateReader(), bindingContext.ModelType);
            //return obj; 
            //var a=controllerContext.HttpContext.Request.ContentType;
            //if (controllerContext == null)
            //{
            //    throw new ArgumentException("controllerContext");
            //}
            //if (bindingContext == null)
            //{
            //    throw new ArgumentException("modelBindingContext");
            //}
            //controllerContext.HttpContext.Request.InputStream.Position = 0;


            //StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
            //string json = reader.ReadToEnd();
            //Newtonsoft.Json.JsonConvert.DeserializeObject<SysModuleSearchParam>(json);


            //var serialize = new DataContractJsonSerializer(bindingContext.ModelType);
            //var obj = serialize.ReadObject(controllerContext.HttpContext.Request.InputStream);
            int pageIndex = controllerContext.HttpContext.Request["page"] == null ? 1 : int.Parse(controllerContext.HttpContext.Request["page"]);
            int pageSize = controllerContext.HttpContext.Request["rows"] == null ? 10 : int.Parse(controllerContext.HttpContext.Request["rows"]);
            var name = controllerContext.HttpContext.Request["MName"];
            var obj = new SysModuleSearchParam()
            {
                PageNumber = pageIndex,
                ModuleName = name,
                PageSize = pageSize
            };
            return obj;
        }
    }

    public class BaseBinder<T> : DefaultModelBinder where T : class, new()
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var obj = new T();
            PropertyInfo[] sourcePropertyInfo = typeof(T).GetProperties();
            if (sourcePropertyInfo.Length == 0)
            {
                return null;
            }
            foreach (var info in sourcePropertyInfo)
            {
                var value = controllerContext.HttpContext.Request[info.Name];
                if (info.CanWrite)
                {
                    info.SetValue(obj, value);
                }
            }
            return obj;
        }
    }

}