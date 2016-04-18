using System.Reflection;
using Abp.Modules;

namespace CPy.Application.Test
{
    public class ApplicationModules:AbpModule
    {
        public override void Initialize()
        {
            base.Initialize();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}