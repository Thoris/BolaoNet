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
        //[AuthorizeRoles(PermissionLevel.User)]
        //[AuthorizeRoles]
        [AllowAnonymous]
        public ActionResult Index()
        {

            if (base.User.FirstName == "")
            {

            }

            return View();
        }
 
    }
}