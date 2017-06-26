using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class AccountHomeController : BaseUserController
    {

        #region Actions

        public new ActionResult Profile()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Logoff()
        {
             return base.Logout();            
        }


        #endregion
    }
}