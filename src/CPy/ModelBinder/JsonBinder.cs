using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using CPy.RequestDto.Pagination;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CPy.ModelBinder
{
    public class JsonBinder : DefaultModelBinder  
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            controllerContext.HttpContext.Request.InputStream.Position = 0;
            StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
            string json = reader.ReadToEnd();

            if (string.IsNullOrEmpty(json))
                return json;

            JObject jsonBody = JObject.Parse(json);
            JsonSerializer js = new JsonSerializer();
            object obj = js.Deserialize(jsonBody.CreateReader(), bindingContext.ModelType);
            return obj;
        }
    }

    public class FormBinder : DefaultModelBinder 
    {

    }

    public class PaginationBinder : DefaultModelBinder 
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var obj = base.BindModel(controllerContext, bindingContext);
            PropertyInfo[] sourcePropertyInfo = bindingContext.ModelType.GetProperties();
            if (sourcePropertyInfo.Length == 0)
            {
                return null;
            }
            foreach (var info in sourcePropertyInfo)
            {
                if (info.Name == "PageNumber")
                {
                    info.SetValue(obj, int.Parse(controllerContext.HttpContext.Request["page"]));
                }
                else if (info.Name == "PageSize")
                {
                    info.SetValue(obj, int.Parse(controllerContext.HttpContext.Request["rows"]));
                }
            }
            return obj;
        }
    }

}