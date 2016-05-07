using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Http;
using UDataCore;
using UDataCore.Uow;
using Unity.WebApi;
using UService.Repositories;
using UService.Test;
using UWeb.Config.Filter;

namespace UWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            if (HttpContext.Current != null)
            {
                container.RegisterType<IUDbContext, UDbcontext>(new PerRequestLifetimeManager());
            }
            else
            {
                container.RegisterType<IUDbContext, UDbcontext>(new ContainerControlledLifetimeManager());
            }
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserTest, UserTest>();
            container.RegisterType<IUow, Uow>();

            GlobalConfiguration.Configuration.DependencyResolver = new UDataCore.Dependency.UnityDependencyResolver(container);
        }

        
    }
}