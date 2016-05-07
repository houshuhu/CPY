using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CPy.Web
{
    public class DeleteBinder : DefaultModelBinder
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
}