﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CPy.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Layout", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Layout.Controllers" }  //默认控制器的命名空间
            ).DataTokens.Add("area", "Layout");   //默认area 的控制器名称
        }
    }
}
