using System.ComponentModel;
using System.Web.Mvc;
using CPy.ModelBinder;
using CPy.Web.Areas.Admin.Controllers;
using CPy.Web.Bootstrapper.IOC;

namespace CPy.Web
{
    public static class BootstrapperConfig
    {
        public static void Run() 
        {
            UnityConfig.RegisterComponents();
        }
    }
}