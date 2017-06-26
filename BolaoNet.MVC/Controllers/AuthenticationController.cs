
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BolaoNet.MVC.Controllers
{

    [AuthorizeRoles]
    public abstract class AuthenticationController : BaseController
    {
        #region Properties
        
        protected Helpers.PersistenceProviders.PersistenceProvider Persist { get; set; }

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

            this.Persist = new Helpers.PersistenceProviders.PersistenceProvider(this);
        }

        #endregion

        #region Actions

        public ActionResult Logout()
        {           
            FormsAuthentication.SignOut();

            this.Persist.Clear();

            return RedirectToLocal("/Account/Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}