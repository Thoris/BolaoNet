using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class AccountController : BaseUserController
    {

        #region Actions

        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        #endregion
    }
}