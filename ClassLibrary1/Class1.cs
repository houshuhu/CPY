using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using CPy.Application.Test.User;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using CPy.Application.Test;
using CPy.Application.Test.Role;
using NUnit.Framework;

namespace ClassLibrary1
{
    public class Class1
    {
        public Class1()
        {
        }

        [Test]
        public void Test()
        {
            var a = Assembly.GetExecutingAssembly();
            var b = typeof(Class1).Assembly;
            IWindsorContainer IocContainer = new WindsorContainer();
            IocContainer.Register(
                Classes.FromAssembly(typeof(RoleApplication).Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );
            IocContainer.Install(FromAssembly.Instance(typeof(RoleApplication).Assembly));
            IUserApplication user = IocContainer.Resolve<IUserApplication>();
            user.Save();

        }

        [Test()]
        public void LogTest()
        {
            LogHelper.LogError("cuowu");
        }

        [Test()]
        public void CallContextTest()
        {
            string Key = "Dbcontext.Unit";
            Guid id = Guid.NewGuid();
            CallContext.LogicalSetData(Key, id);
            var a = CallContext.LogicalGetData(Key);

            Guid id1 = Guid.NewGuid();
            CallContext.LogicalSetData(Key, id1);
            var a1 = CallContext.LogicalGetData(Key);
        }
        [Test]
        public void DoSomething()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> b = list.Select(delegate(int t)
            {
                int a = 0;
                a = t;
                return a;
            }).ToList();
        }
    }
}
