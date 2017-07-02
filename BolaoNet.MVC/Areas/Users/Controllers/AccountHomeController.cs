using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class AccountHomeController : BaseUserAreaController
    {

        #region Actions

        [HttpGet]
        public ActionResult Index ()
        {
            return View();
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public new ActionResult Profile(ViewModels.Users.UserProfileViewModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ViewModels.Users.UserChangePasswordViewModel model)
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