using System.Web.Mvc;
using CPy.RequestDto.Pagination;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CPy.ModelBinder
{
    public class BaseModelBinder<T> : DefaultModelBinder where T : class
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var obj = base.BindModel(controllerContext, bindingContext);
            if (controllerContext.HttpContext.Request.ContentType == "application/x-www-form-urlencoded; charset=UTF-8")
            {
                if (typeof(IPagination).IsAssignableFrom(bindingContext.ModelType))
                {
                    return new PaginationBinder().BindModel(controllerContext, bindingContext);
                }
                return new FormBinder().BindModel(controllerContext, bindingContext);
            }
            if (controllerContext.HttpContext.Request.ContentType == "application/json; charset=utf-8")
            {
                return new JsonBinder().BindModel(controllerContext, bindingContext);
            }
            return obj;
        }
    }
}