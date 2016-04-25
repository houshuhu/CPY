using System.Web;
using CPy.Application.Admin;
using CPy.Core.Dependency;
using CPy.Core.UnitofWork;
using CPy.Domain.Repositories;
using CPy.EntityFrameWork;
using CPy.EntityFrameWork.EfRepository;
using CPy.EntityFrameWork.UnitofWork;
using CPy.IApplication.Admin;
using Microsoft.Practices.Unity;

namespace CPy.Web
{
    public static class IOCConfig
    {
        public static void BootstraperRegister(UnityContainer container)
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
        public static void ApplicationRegister(UnityContainer container)
        {
            container.RegisterType<IUserApplication, UserApplication>();
        }

        public static void RepositoryRegister(UnityContainer container)
        {

        }
    }
}