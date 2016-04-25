using System;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace CPy.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here

            IOCConfig.BootstraperRegister(container);
            IOCConfig.ApplicationRegister(container);
            IOCConfig.RepositoryRegister(container);

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        
    }
}