using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Controllers
{
    [AuthorizeRoles]
    public class HomeController : AuthorizationController
    {
        #region Actions
        
        //[AuthorizeRoles(PermissionLevel.User)]
        public ActionResult Index()
        {

            return RedirectToAction("Index", "AccountHome", new { area = "Users" });
            //if (User.FirstName == "")
            //{

            //}

            //return View();
        }

        #endregion
    }
}