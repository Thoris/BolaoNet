﻿using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BolaoNet.MVC.Tests.Mocks
{

    /// <summary>
    /// This class of MVC Mock helpers is originally based on Scott Hanselman's 2008 post:
    /// http://www.hanselman.com/blog/ASPNETMVCSessionAtMix08TDDAndMvcMockHelpers.aspx
    /// 
    /// This has been updated and tweaked to work with MVC 3 / 4 projects (it hasn't been tested with MVC 
    /// 1 / 2 but may work there) and also based my use cases
    /// </summary>
    public static class MvcMockHelpers
    {
        #region Mock HttpContext factories

        public static HttpContextBase MockHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();

            request.Setup(r => r.AppRelativeCurrentExecutionFilePath).Returns("/");
            request.Setup(r => r.ApplicationPath).Returns("/");

            response.Setup(s => s.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);
            response.SetupProperty(res => res.StatusCode, (int)System.Net.HttpStatusCode.OK);

            context.Setup(h => h.Request).Returns(request.Object);
            context.Setup(h => h.Response).Returns(response.Object);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);





            context.SetupGet(x => x.Response.Cookies).Returns(new HttpCookieCollection()); // still can't call the Clear() method
            //context.SetupGet(p => p.User.Identity.Name).Returns("blah");
            //context.SetupGet(p => p.User.Identity.IsAuthenticated).Returns(true);



            //var serverMock = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            //serverMock.Setup(i => i.MapPath(It.IsAny<String>()))
            //   .Returns((String a) => a.Replace("~/", @"C:\testserverdir\").Replace("/", @"\"));
            server.Setup(i => i.MapPath(It.IsAny<String>()))
               .Returns((String a) => a.Replace("~/", @"..\..\..\BolaoNet.MVC\").Replace("/", @"\"));

            return context.Object;
        }

        public static HttpContextBase MockHttpContext(string url)
        {
            var context = MockHttpContext();
            context.Request.SetupRequestUrl(url);
            return context;
        }

        #endregion

        #region Extension methods

        public static void SetMockControllerContext(this Controller controller,
            HttpContextBase httpContext = null,
            RouteData routeData = null,
            RouteCollection routes = null)
        {
            //If values not passed then initialise
            routeData = routeData ?? new RouteData();
            routes = routes ?? RouteTable.Routes;
            httpContext = httpContext ?? MockHttpContext();

            var requestContext = new RequestContext(httpContext, routeData);
            var context = new ControllerContext(requestContext, controller);

            //Modify controller
            controller.Url = new UrlHelper(requestContext, routes);
            controller.ControllerContext = context;


        }

        public static void SetMockControllerContext(this Controller controller, IPrincipal user, 
            HttpContextBase httpContext = null, RouteData routeData = null, RouteCollection routes = null)
        {
            //If values not passed then initialise
            routeData = routeData ?? new RouteData();
            routes = routes ?? RouteTable.Routes;
            httpContext = httpContext ?? MockHttpContext();

            var requestContext = new RequestContext(httpContext, routeData);
            var context = new ControllerContext(requestContext, controller);

            //Modify controller
            controller.Url = new UrlHelper(requestContext, routes);
            controller.ControllerContext = context;



            SetupUser(controller.HttpContext, user);


            //var mock = Mock.Get(context);
            

            //var controllerContext = new Mock<ControllerContext>();
            //var principal = new Moq.Mock<IPrincipal>();
            //principal.Setup(p => p.IsInRole("Administrator")).Returns(true);
            //principal.SetupGet(x => x.Identity.Name).Returns("thoris");
            //controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            //controller.ControllerContext = controllerContext.Object;

            

            //context.Setup(c => c.User).Returns(user.Object);
            //user.Setup(c => c.Identity).Returns(identity.Object);
            //identity.Setup(i => i.IsAuthenticated).Returns(true);
            //identity.Setup(i => i.Name).Returns("admin");

        }
        public static void SetupUser(this HttpContextBase context, IPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException("principal");

            Mock.Get(context)
              .Setup(ctx => ctx.User)
              .Returns(principal);
        }
        public static void SetHttpMethodResult(this HttpRequestBase request, string httpMethod)
        {
            Mock.Get(request).Setup(req => req.HttpMethod).Returns(httpMethod);
        }

        public static void SetupRequestUrl(this HttpRequestBase request, string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (!url.StartsWith("~/"))
                throw new ArgumentException("Sorry, we expect a virtual url starting with \"~/\".");

            var mock = Mock.Get(request);

            mock.Setup(req => req.QueryString).Returns(GetQueryStringParameters(url));
            mock.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns(GetUrlFileName(url));
            mock.Setup(req => req.PathInfo).Returns(string.Empty);
        }


        /// <summary>
        /// Facilitates unit testing of anonymouse types - taken from here:
        /// http://stackoverflow.com/a/5012105/761388
        /// </summary>
        public static object GetReflectedProperty(this object obj, string propertyName)
        {
            obj.ThrowIfNull("obj");
            propertyName.ThrowIfNull("propertyName");

            var property = obj.GetType().GetProperty(propertyName);

            if (property == null)
                return null;

            return property.GetValue(obj, null);
        }

        public static T ThrowIfNull<T>(this T value, string variableName) where T : class
        {
            if (value == null)
                throw new NullReferenceException(
                    string.Format("Value is Null: {0}", variableName));

            return value;
        }

        #endregion

        #region Private

        static string GetUrlFileName(string url)
        {
            return (url.Contains("?"))
                ? url.Substring(0, url.IndexOf("?"))
                : url;
        }

        static NameValueCollection GetQueryStringParameters(string url)
        {
            if (url.Contains("?"))
            {
                var parameters = new NameValueCollection();

                var parts = url.Split("?".ToCharArray());
                var keys = parts[1].Split("&".ToCharArray());

                foreach (var key in keys)
                {
                    var part = key.Split("=".ToCharArray());
                    parameters.Add(part[0], part[1]);
                }

                return parameters;
            }

            return null;
        }

        #endregion
    }
}
