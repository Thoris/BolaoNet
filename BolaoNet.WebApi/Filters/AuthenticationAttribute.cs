using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace BolaoNet.WebApi.Filters
{
    public class AuthenticationAttribute : AuthorizeAttribute
    {
        #region Methods

        private bool ValidateKey(string token)
        {
            string tokenConfig =System.Configuration.ConfigurationManager.AppSettings["Token"];

            if (tokenConfig == null)
                return true;

            if (string.Compare(token, tokenConfig) == 0)
                return true;
            else
                return false;

           // return false;
        }

        #endregion


        #region Events

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //return;

            if (!actionContext.Request.Headers.Contains("AuthenticationToken"))
            {
                throw new Exception("Authentication Header not set");
            }
            else if (actionContext.Request.Headers.GetValues("AuthenticationToken") != null )
            {
                string token = Convert.ToString(actionContext.Request.Headers.GetValues("AuthenticationToken").FirstOrDefault());


                if (!string.IsNullOrEmpty(token) && ValidateKey(token))
                {
                    HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                }
                else
                {
                    HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                    throw new Exception("Not Authorized");
                }

                return;
            }
            else
            {
                actionContext.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(
                                                "Invalid Authentication.",
                                                Encoding.UTF8,
                                                "application/json"
                                                )
                };

                throw new Exception("No valid authentication");
            }

            base.OnAuthorization(actionContext);
        }

        #endregion
    }
}