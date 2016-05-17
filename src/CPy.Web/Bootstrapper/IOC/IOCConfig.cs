using System.Web;
using CPy.Application.Admin;
using CPy.Core.UnitofWork;
using CPy.Domain.Repositories;
using CPy.EntityFrameWork;
using CPy.EntityFrameWork.EfRepository;
using CPy.EntityFrameWork.UnitofWork;
using CPy.IApplication.Admin;
using Microsoft.Practices.Unity;

namespace CPy.Web.Bootstrapper.IOC
{
    public static class IOCConfig
    {
        public static void KernelRegister(UnityContainer container)
        {
            if (HttpContext.Current != null)
            {
                //此处WebApi:PerRequestLifetimeManager引用路径：CPy.Dependency.WebApi
                container.RegisterType<ICPyDbContext, CPyDbContext>(new PerRequestLifetimeManager());
            }
            else
            {
                container.RegisterType<ICPyDbContext, CPyDbContext>(new ContainerControlledLifetimeManager());
            }
            container.RegisterType<IUnitofWorkContext, UnitOfWorkContext>();
            container.RegisterType<IUnitofWork, UnitofWork>();

            container.RegisterType(typeof(IRepository<>), typeof(BaseRepostitory<>));

            container.RegisterType<IUserApplication, UserApplication>();
        }

        public static void ApplicationRegister(UnityContainer container)
        {
            container.RegisterType<IUserApplication, UserApplication>();
            container.RegisterType<ISysModuleApplication, SysModuleApplication>();
            container.RegisterType<ISysFunctionApplication,SysFunctionApplication>();
        }

        public static void RepositoryRegister(UnityContainer container)
        {

        }
    }
}