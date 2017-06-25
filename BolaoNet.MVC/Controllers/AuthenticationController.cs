
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BolaoNet.MVC.Controllers
{
    public abstract class AuthenticationController : BaseController
    {
        #region Properties

        /// <summary>
        /// we inherit all controllers from this basecontroller.
        /// basicly we access usercontext data from all controllers by user variable
        /// User.FirstName + " " + User.LastName
        /// </summary>
        protected virtual new CustomUserPrincipal User
        {
            get { return HttpContext.User as CustomUserPrincipal; }
        }
        protected virtual Domain.Entities.Users.User UserLogged
        {
            get
            {
                if (this.User != null)
                {
                    return new Domain.Entities.Users.User(this.User.UserName)
                    {
                        FullName = this.User.FullName
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Constructors/Destructors

        public AuthenticationController()
        {

        }

        #endregion

        #region Actions

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
       

        #endregion
    }
}