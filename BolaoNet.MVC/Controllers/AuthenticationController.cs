
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{
    public class AuthenticationController : BaseController
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

        #endregion
    }
}