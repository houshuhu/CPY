using System.Web.Http;
using System.Web.Mvc;
using CPy.Dependency.Mvc;
using Microsoft.Practices.Unity;

namespace CPy.Web.Bootstrapper.IOC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here

            IOCConfig.KernelRegister(container);
            IOCConfig.ApplicationRegister(container);
            IOCConfig.RepositoryRegister(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //WebApi  UnityDependencyResolverÒýÓÃÎª£ºCPy.Dependency.WebApi
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        
    }
}