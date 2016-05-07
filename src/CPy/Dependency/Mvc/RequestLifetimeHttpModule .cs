using System.Web;

namespace CPy.Dependency.Mvc
{
    public class RequestLifetimeHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += (sender, e) => UnityDependencyResolver.DisposeOfChildContainer();
        }

        public void Dispose()
        {
            // nothing to do here
        }  
    }
}