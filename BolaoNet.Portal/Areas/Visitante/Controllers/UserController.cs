using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.Portal.Areas.Visitante.Controllers
{
    public class UserController : Controller
    {
        #region Actions

        public ActionResult Login()
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
        public ActionResult RecoverPassword()
        {
            return View();
        }

        #endregion
    }
}