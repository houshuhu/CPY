using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace UWeb
{
    public class CustomControllerActivator : IControllerActivator 
    {

        public IController Create(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return (IController) GlobalConfiguration.Configuration.DependencyResolver.GetService(controllerType);
            //return DependencyResolver.Current.GetService() as IHttpController;
        }
    }
}