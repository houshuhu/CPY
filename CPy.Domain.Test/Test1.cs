using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CPy.Application.Test;
using CPy.Application.Test.User;
using NUnit.Framework;

namespace CPy.Domain.Test
{
    public class Test1 : BaseTest
    {
        [Test]
        public void DITest()
        {
            string a = "12-10";
            var b=a.Split('-');

        }
    }

    public class BaseTest
    {
        private IIocManager LocalIocManager { get; set; }

        public BaseTest()
        {
            LocalIocManager = new IocManager();
            //ApplicationModules modules=new ApplicationModules();
            //modules.Initialize();
        }
    }
}