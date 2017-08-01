using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BolaoNet.MVC.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        #region Variables

        private readonly PermissionLevel[] allowedPermissionLevels;

        #endregion

        #region Properties

        protected virtual CustomUserPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomUserPrincipal; }
        }

        #endregion

        #region Constructors/Destructors

        public AuthorizeRolesAttribute(params PermissionLevel[] allowedRoles)
        {
            //var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(PermissionLevel), x));
            //Roles = string.Join(",", allowedRolesAsStrings);

            Roles = "";
            for (int c = 0; c < allowedRoles.Length; c++ )
            {
                int pos = (int) allowedRoles[c];
                if (c > 0)
                    Roles += ",";
                
                Roles += PermissionLevelDesc.Levels[pos];
            }


            this.allowedPermissionLevels = allowedRoles;
            //How to use: [AuthorizeRoles(UserPermissionLevel.Admin, UserPermissionLevel.User)]
        }

        #endregion

        #region Methods


        //private IList<PermissionLevel> GetApprovedUserPermissionlevels()
        //{
        //    IList<PermissionLevel> theApprovedRoles = new List<PermissionLevel>();

        //    // theApprovedRoles.Add(UserPermissionLevelEnum.SuperAdmin);
        //    //  theApprovedRoles.Add(UserPermissionLevelEnum.Admin);

        //    return theApprovedRoles;
        //}

        #endregion

        #region AuthorizeAttributeMembers


        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            //If it is defined as allow AllowAnonymousAttribute
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }




            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                //var authorizedUser = ConfigurationManager.AppSettings["UserConfigKey"];
                //var authorizedRoles = ConfigurationManager.AppSettings["RoleConfigKey"];

                //Users = string.IsNullOrEmpty(Users) ? authorizedUser : Users;
                //Roles = string.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;

                if (!string.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { area = "", controller = "Error", action = "AccessDenied" }));
                    }
                }

                if (!string.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.UserName))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { area = "", controller = "Error", action = "AccessDenied" }));
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { area = "", controller = "Account", action = "Login" }));

                
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            //IList<PermissionLevel> theApprovedPermissionLevelList = GetApprovedUserPermissionlevels();

            //foreach (PermissionLevel permissionLevel in allowedPermissionLevels)
            //{
            //    if (theApprovedPermissionLevelList.Any(a => a == permissionLevel) == true)
            //    {
            //        //authorize = true;
            //        return true;
            //    }
            //}

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { area = "", controller = "Error", action = "AccessDenied" }));
            }
        }


        #endregion

    }

}