using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{ 
    public abstract class AuthorizationController : AuthenticationController
    {

        #region Constructors/Destructors

        public AuthorizationController()
        {
        }

        #endregion

        #region Methods

        public bool IsUserInRole(PermissionLevel [] levels)
        {
            CustomUserPrincipal user = this.HttpContext.User as CustomUserPrincipal;

            if (user != null)
            {
                //user.Roles
            }

            return false;
        }

        #endregion
    }
}