﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace UWeb.Config
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            if (controllerType == null)
                return null;

            return _container.Resolve(controllerType) as IController;
        }
       

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }
    }
}