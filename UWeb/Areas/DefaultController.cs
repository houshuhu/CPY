using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using UDataCore;
using UService.Test;
using UWeb.Config.Filter;

namespace UWeb.Areas
{
    [BaseExcepetionFilter]
    public class DefaultController : ApiController
    {
        private readonly IUserTest _userTest;

        public DefaultController(IUserTest userTest)
        {
            _userTest = userTest;
        }

        [System.Web.Http.HttpPost]
        public JsonResult Add()
        {
            //var userservice = IocContext.WindsorContainer.Resolve<IUserTest>();
            _userTest.Save();
            
            return new JsonResult(){Data = 1};
        }
    }
}
