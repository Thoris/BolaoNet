using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace BolaoNet.Services.Controllers
{
    /// <summary>
    /// Classe que possui funcionalidades básicas de autenticação do usuários para o acesso às funcionalidades básicas de gerenciamento.
    /// </summary>
    public class AuthenticationController : BaseApiController
    {
        public override System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }




        //Assuming the request goes into the ApiController scope, the operation order is as below:

        //The ExecuteAsync method of the ApiController is invoked.
        //The Initialize method of the ApiController is invoked.
        //The registered Action Selector is retrieved.
        //The SelectAction method of the registered action selector is invoked. If only one action method is matched, the pipeline continues.
        //All registered Filters for the selected action is retrieved.
        //The Authorization Filters are called. The authorization filter can decide either to let the pipeline to continue executing or to terminate the pipeline.
        //If Authorization Filters didn't terminate the request, action parameter bindings are performed.
        //ApiController.ModelState is set.
        //Action Filters are invoked. The Action Filters an decide either to let the pipeline to continue executing or terminate the pipeline.
        //If Action Filters didn't terminate the request, registered Action Invoker is retrieved.
        //The InvokeActionAsync method of the registered Action Invoker is called to invoked the selected action method.
        //Note: If any exception occurs from the execution of the Authorization Filters to the execution of the action method, the exception filters are be called.


        //static string GetToken(string url, string userName, string password)
        //{
        //    var pairs = new List<KeyValuePair<string, string>>
        //            {
        //                new KeyValuePair<string, string>( "grant_type", "password" ), 
        //                new KeyValuePair<string, string>( "username", userName ), 
        //                new KeyValuePair<string, string> ( "Password", password )
        //            };
        //    var content = new FormUrlEncodedContent(pairs);
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    using (var client = new HttpClient())
        //    {
        //        var response = client.PostAsync(url + "Token", content).Result;
        //        return response.Content.ReadAsStringAsync().Result;
        //    }
        //}

        protected override System.Web.Http.Results.FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, System.Net.Http.Formatting.MediaTypeFormatter formatter, System.Net.Http.Headers.MediaTypeHeaderValue mediaType)
        {
            return base.Content<T>(statusCode, value, formatter, mediaType);
        }
       

        protected override System.Web.Http.Results.OkResult Ok()
        {
            return base.Ok();
        }

        protected override System.Web.Http.Results.UnauthorizedResult Unauthorized(IEnumerable<System.Net.Http.Headers.AuthenticationHeaderValue> challenges)
        {
            return base.Unauthorized(challenges);
        }

        protected override System.Web.Http.Results.StatusCodeResult StatusCode(HttpStatusCode status)
        {
            return base.StatusCode(status);
        }
        protected override System.Web.Http.Results.ResponseMessageResult ResponseMessage(HttpResponseMessage response)
        {
            return base.ResponseMessage(response);
        }
        protected override System.Web.Http.Results.RedirectToRouteResult RedirectToRoute(string routeName, IDictionary<string, object> routeValues)
        {
            return base.RedirectToRoute(routeName, routeValues);
        }
        protected override System.Web.Http.Results.RedirectResult Redirect(Uri location)
        {
            return base.Redirect(location);
        }
        protected override System.Web.Http.Results.JsonResult<T> Json<T>(T content, Newtonsoft.Json.JsonSerializerSettings serializerSettings, System.Text.Encoding encoding)
        {
            return base.Json<T>(content, serializerSettings, encoding);
        }
        protected override System.Web.Http.Results.RedirectResult Redirect(string location)
        {
            return base.Redirect(location);
        }
        protected override System.Web.Http.Results.NegotiatedContentResult<T> Content<T>(HttpStatusCode statusCode, T value)
        {
            return base.Content<T>(statusCode, value);
        }
        protected override System.Web.Http.Results.OkNegotiatedContentResult<T> Ok<T>(T content)
        {
            return base.Ok<T>(content);
        }
    }
}