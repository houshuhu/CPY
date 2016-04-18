using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using IActionFilter = System.Web.Mvc.IActionFilter;

namespace UWeb.Config.Filter
{
    public class BaseExcepetionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            var exception = actionExecutedContext.Exception;
            if (exception==null)
            {
                return;
            }
            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, exception);
        }
    }

    public interface IActionMethod
    {
        void DoSomething();
    }

    public class ActionMethod : IActionMethod
    {
        public void DoSomething()
        {
            var list = new List<int>() {1, 2, 3, 4, 5};
            List<int> b = list.Select(delegate(int t)
            {
                int a=0;
                a = t;
                return a;
            }).ToList();
        }
    }

    public class MyActionFilter : IActionFilter
    {
        private readonly IActionMethod _actionMethod;


        public MyActionFilter(IActionMethod actionMethod)
        {
            _actionMethod = actionMethod;
        }


        public void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            _actionMethod.DoSomething();
        }
    }

    public class MyActionFilterAttribute : Attribute
    {

    }
}