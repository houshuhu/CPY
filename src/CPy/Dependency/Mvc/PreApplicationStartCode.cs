using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace CPy.Dependency.Mvc
{
    public class PreApplicationStartCode
    {
        private static bool _isStarting;

        public static void PreStart()
        {
            if (!_isStarting)
            {
                _isStarting = true;

                DynamicModuleUtility.RegisterModule(typeof(RequestLifetimeHttpModule));
            }
        } 
    }
}