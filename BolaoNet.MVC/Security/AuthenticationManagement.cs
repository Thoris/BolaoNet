using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BolaoNet.MVC.Security
{
    public class AuthenticationManagement
    {
        #region Methods

        //public static void SaveAuthentication(HttpResponseBase response, UserModelState model, bool rememberMe)
        //{        
        //    var userData = JsonConvert.SerializeObject(model);
        //    var authenticationTicket = new FormsAuthenticationTicket(
        //        1,
        //        model.UserName,
        //        DateTime.Now,
        //        DateTime.Now.AddHours(1),
        //        rememberMe,
        //        userData);

        //    var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);
        //    var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

        //    response.Cookies.Add(httpCookie);

        //}

        public static void SaveAuthentication(HttpResponseBase response, UserModelState model, bool rememberMe)
        {
            var userData = JsonConvert.SerializeObject(model);

            // tempo de expiração
            DateTime issued = DateTime.Now;
            DateTime expiration = rememberMe
                ? issued.AddDays(30)     // persistente
                : issued.AddMinutes(60); // sessão curta

            var authenticationTicket = new FormsAuthenticationTicket(
                1,
                model.UserName,
                issued,
                expiration,
                rememberMe,
                userData
            );

            var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);

            var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL, // true se usar HTTPS
                SameSite = SameSiteMode.Lax
            };

            // 🔥 ESSENCIAL para "Lembrar-me"
            if (rememberMe)
            {
                httpCookie.Expires = expiration;
            }

            response.Cookies.Add(httpCookie);
        }

        public static void SetContextAuthentication(HttpRequest request)
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

        public static void ClearContext()
        {
            FormsAuthentication.SignOut();
        }

        #endregion

    }
}