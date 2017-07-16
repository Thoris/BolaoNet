using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BolaoNet.MVC.Security
{
    public class CookieManager : ICookieManager
    {
        #region Methods

        public void SaveAuthentication(HttpResponseBase response, UserModelState model, bool rememberMe, int expiration = 10)
        {
            var userData = JsonConvert.SerializeObject(model);
            var authenticationTicket = new FormsAuthenticationTicket(
                1,
                model.UserName,
                DateTime.Now,
                DateTime.Now.AddHours(expiration),
                rememberMe,
                userData);

            var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);
            var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            if (response != null)
                response.Cookies.Add(httpCookie);
        }

        public void SetContextAuthentication(HttpRequest request)
        {
            var authCookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null)
                {
                    var serializeModel = JsonConvert.DeserializeObject<UserModelState>(authTicket.UserData);

                    if (serializeModel != null)
                    {
                        var newUser = new CustomUserPrincipal(authTicket.Name)
                        {
                            UserName = serializeModel.UserName,
                            FirstName = serializeModel.FirstName,
                            LastName = serializeModel.LastName,
                            Roles = serializeModel.Roles
                        };

                        HttpContext.Current.User = newUser;
                    }
                }
            }
        }

        public void ClearContext()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}