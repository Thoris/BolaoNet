using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BolaoNet.MVC.Security
{
    public class CustomUserPrincipal : IPrincipal
    {
        #region Properties

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
        public IIdentity Identity { get; private set; }

        #endregion

        #region Constructors/Destructors

        public CustomUserPrincipal(string username)
        {
            this.UserName = username;
            this.Identity = new GenericIdentity(username);
        }

        #endregion

        #region Methods

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}