using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{ 
    //[AuthorizeRoles(PermissionLevel.Admin, PermissionLevel.User)]
    public abstract class AuthorizationController : AuthenticationController
    {
        #region Constructors/Destructors

        public AuthorizationController()
        {

        }

        #endregion
    }
}