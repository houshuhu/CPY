using System;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Http;
using CPy.Application.User;
using CPy.Core.Dependency;
using CPy.Core.UnitofWork;
using CPy.Domain.Entities;
using CPy.Domain.Repositories;
using CPy.EntityFrameWork;
using CPy.EntityFrameWork.EfRepository;
using CPy.EntityFrameWork.UnitofWork;
using CPy.IApplication.User;

namespace CPy.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            Register(container);

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        public static void Register(UnityContainer container)
        {
            if (HttpContext.Current != null)
            {
                container.RegisterType<ICPyDbContext, CPyDbContext>(new PerRequestLifetimeManager());
            }
            else
            {
                container.RegisterType<ICPyDbContext, CPyDbContext>(new ContainerControlledLifetimeManager());
            }
            container.RegisterType<IUnitofWorkContext, UnitOfWorkContext>();
            container.RegisterType<IUnitofWork, UnitofWork>();
            //container.RegisterType<IRepository<IEntity<Guid>>, BaseRepostitory<IEntity<Guid>>>();

            container.RegisterType(typeof(IRepository<>), typeof(BaseRepostitory<>));

            container.RegisterType<IUserApplication, UserApplication>();
        }
    }
}