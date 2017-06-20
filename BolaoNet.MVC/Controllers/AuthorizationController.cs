using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{ 
    //[AuthorizeRoles(PermissionLevel.Admin, PermissionLevel.User)]
    public class AuthorizationController : AuthenticationController
    {
    }
}