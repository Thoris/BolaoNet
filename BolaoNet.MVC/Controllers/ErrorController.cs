using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Controllers
{
    public class ErrorController : BaseController
    {
        #region Actions

        public ActionResult AccessDenied()
        {
            //Security.AuthenticationManagement.ClearContext();

            return View();
        }

        #endregion
    }
}