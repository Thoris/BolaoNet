using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.Portal.Areas.Users.Controllers
{
    public class AccessController : Controller
    {
        #region Actions

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult RegistrationForm()
        {
            return View();
        }
        public ActionResult ActivateCode()
        {
            return View();
        }
        #endregion
    }
}