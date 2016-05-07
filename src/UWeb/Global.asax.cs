using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using UDataCore;
using UDataCore.Uow;
using UService.Repositories;
using UWeb.Config;
using Component = Castle.MicroKernel.Registration.Component;

namespace UWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //WireUpDependencyResolvers();
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void WireUpDependencyResolvers()
        {
            Castle.Core.Resource.ConfigResource source = new Castle.Core.Resource.ConfigResource();
            XmlInterpreter interpreter = new XmlInterpreter(source);
            IocContext.WindsorContainer = new WindsorContainer(interpreter);
            IocContext.WindsorContainer.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
            IocContext.WindsorContainer.Register(Classes.FromThisAssembly().BasedOn<Controller>().LifestylePerWebRequest());
            //IocContext.WindsorContainer.Register(
            //    Component.For<IUnitOfWork>().ImplementedBy<DemoUnitOfWorkContext>().LifestylePerThread());
            IocContext.WindsorContainer.Register(
                Component.For<IUow>().ImplementedBy<Uow>().LifestylePerThread());
            IocContext.WindsorContainer.Register(
                Component.For<IUDbContext>().ImplementedBy<UDbcontext>().LifestylePerThread());
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(IocContext.WindsorContainer);
            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IocContext.WindsorContainer));
        }
    }
}
