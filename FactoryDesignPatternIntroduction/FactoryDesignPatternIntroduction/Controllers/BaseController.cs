using System;
using Logger;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FactoryDesignPatternIntroduction.Controllers
{
    /*
        Why we need to move the Singleton code to BaseController?
        The idea of moving the code is to inherit the BaseController to the rest of the controllers so that all the exceptions can be handled at one place and any
        model related refresh updates in the controllers will not impact the auto generated code of the controllers.
    */

    public class BaseController : Controller
    {
        private ILog _ILog;
        public BaseController()
        {
            _ILog = Log.GetInstance;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
    }
}