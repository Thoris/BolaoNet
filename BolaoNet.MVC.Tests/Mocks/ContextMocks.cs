using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BolaoNet.MVC.Tests.Mocks
{
    public class ContextMocks
    {
        public Moq.Mock<HttpContextBase> HttpContext { get; set; }
        public Moq.Mock<HttpRequestBase> Request { get; set; }
        public RouteData RouteData { get; set; }




        private static HttpContextBase MakeFakeContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();

            context.Setup(c => c.Request).Returns(request.Object);
            context.Setup(c => c.Response).Returns(response.Object);
            context.Setup(c => c.Session).Returns(session.Object);
            context.Setup(c => c.Server).Returns(server.Object);
            context.Setup(c => c.User).Returns(user.Object);
            user.Setup(c => c.Identity).Returns(identity.Object);
            identity.Setup(i => i.IsAuthenticated).Returns(true);
            identity.Setup(i => i.Name).Returns("admin");

            return context.Object;
        }


        public ContextMocks(Controller controller)
        {
            var RoutingRequestContext = new Mock<RequestContext>(MockBehavior.Loose);
            var ActionExecuting = new Mock<ActionExecutingContext>(MockBehavior.Loose);
            var Http = new Mock<HttpContextBase>(MockBehavior.Loose);
            var Server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            var Response = new Mock<HttpResponseBase>(MockBehavior.Loose);
            var Request = new Mock<HttpRequestBase>(MockBehavior.Loose);
            var Session = new Mock<HttpSessionStateBase>(MockBehavior.Loose);
            var Cookies = new HttpCookieCollection();

            RoutingRequestContext.SetupGet(c => c.HttpContext).Returns(Http.Object);
            ActionExecuting.SetupGet(c => c.HttpContext).Returns(Http.Object);
            Http.SetupGet(c => c.Request).Returns(Request.Object);
            Http.SetupGet(c => c.Response).Returns(Response.Object);
            Http.SetupGet(c => c.Server).Returns(Server.Object);
            Http.SetupGet(c => c.Session).Returns(Session.Object);
            Request.Setup(c => c.Cookies).Returns(Cookies);
            Response.Setup(c => c.Cookies).Returns(Cookies);

            RequestContext rc = new RequestContext(HttpContext.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(rc, controller);
        }


        //public ContextMocks(Controller controller)
        //{
        //    //define context objects
        //    HttpContext = new Moq.Mock<HttpContextBase>();
        //    HttpContext.Setup(x => x.Request).Returns(Request.Object);
        //    //you would setup Response, Session, etc similarly with either mocks or fakes

        //    //apply context to controller
        //    RequestContext rc = new RequestContext(HttpContext.Object, new RouteData());
        //    controller.ControllerContext = new ControllerContext(rc, controller);
        //}



//public MockWebContext()
//{
//    RoutingRequestContext = new Mock<RequestContext>(MockBehavior.Loose);
//    ActionExecuting = new Mock<ActionExecutingContext>(MockBehavior.Loose);
//    Http = new Mock<HttpContextBase>(MockBehavior.Loose);
//    Server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
//    Response = new Mock<HttpResponseBase>(MockBehavior.Loose);
//    Request = new Mock<HttpRequestBase>(MockBehavior.Loose);
//    Session = new Mock<HttpSessionStateBase>(MockBehavior.Loose);
//    Cookies = new HttpCookieCollection();
 
//    RoutingRequestContext.SetupGet(c => c.HttpContext).Returns(Http.Object);
//    ActionExecuting.SetupGet(c => c.HttpContext).Returns(Http.Object);
//    Http.SetupGet(c => c.Request).Returns(Request.Object);
//    Http.SetupGet(c => c.Response).Returns(Response.Object);
//    Http.SetupGet(c => c.Server).Returns(Server.Object);
//    Http.SetupGet(c => c.Session).Returns(Session.Object);
//    Request.Setup(c => c.Cookies).Returns(Cookies);
//    Response.Setup(c => c.Cookies).Returns(Cookies);
//}


        //public static void SetupRequestUrl(this HttpRequestBase request, Uri uri)
        //{
        //    if (uri == null)
        //        throw new ArgumentNullException("url");

        //    var mock = Mock.Get(request);

        //    //removed exception and replaced it by using local path prefixed with ~
        //    var localPath = "~" + uri.LocalPath;

        //    mock.Setup(req => req.QueryString).Returns(GetQueryStringParameters(localPath));
        //    mock.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns(GetUrlFileName(localPath));
        //    mock.Setup(req => req.PathInfo).Returns(string.Empty);
        //    mock.Setup(req => req.Path).Returns(uri.LocalPath);

        //    //setup the uri object for the request context
        //    mock.Setup(req => req.Url).Returns(uri);
        //}

        //private static HttpContextBase MakeFakeContext()
        //{
        //    var context = new Mock<HttpContextBase>();
        //    var request = new Mock<HttpRequestBase>();
        //    var response = new Mock<HttpResponseBase>();
        //    var session = new Mock<HttpSessionStateBase>();
        //    var server = new Mock<HttpServerUtilityBase>();
        //    var user = new Mock<IPrincipal>();
        //    var identity = new Mock<IIdentity>();

        //    context.Setup(c => c.Request).Returns(request.Object);
        //    context.Setup(c => c.Response).Returns(response.Object);
        //    context.Setup(c => c.Session).Returns(session.Object);
        //    context.Setup(c => c.Server).Returns(server.Object);
        //    context.Setup(c => c.User).Returns(user.Object);
        //    user.Setup(c => c.Identity).Returns(identity.Object);
        //    identity.Setup(i => i.IsAuthenticated).Returns(true);
        //    identity.Setup(i => i.Name).Returns("admin");

        //    return context.Object;
        //}



        //private void test()
        //{
        //    var controller = new MyController();

        //    var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
        //    var response = new Mock<HttpResponseBase>(MockBehavior.Strict);

        //    var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
        //    request.Setup(r => r.UserHostAddress).Returns("127.0.0.1");

        //    var session = new Mock<HttpSessionStateBase>();
        //    session.Setup(s => s.SessionID).Returns(Guid.NewGuid().ToString());

        //    var context = new Mock<HttpContextBase>();
        //    context.SetupGet(c => c.Request).Returns(request.Object);
        //    context.SetupGet(c => c.Response).Returns(response.Object);
        //    context.SetupGet(c => c.Server).Returns(server.Object);
        //    context.SetupGet(c => c.Session).Returns(session.Object);

        //    controller.ControllerContext = new ControllerContext(context.Object,
        //                                      new RouteData(), controller);
        //}




    //    public void SetupTests()
    //    {
    //        // Setup Rhino Mocks
    //        rmContext = MockRepository.GenerateMock<HttpContextBase>();
    //        rmRequest = MockRepository.GenerateMock<HttpRequestBase>();
    //        rmContext.Stub(x => x.Request).Return(rmRequest);
    //        // Setup Moq
    //        moqContext = new Mock<HttpContextBase>();
    //        moqRequest = new Mock<HttpRequestBase>();
    //        moqContext.Setup(x => x.Request).Returns(moqRequest.Object);
    //        // Create a "fake" form
    //        formValues = new NameValueCollection
    //{
    //    { "FirstName", "Jonathan" }, 
    //    { "LastName", "Danylko" }                
    //};
    //    }
    }





    ///// <summary>
    ///// This class of MVC Mock helpers is originally based on Scott Hanselman's 2008 post:
    ///// http://www.hanselman.com/blog/ASPNETMVCSessionAtMix08TDDAndMvcMockHelpers.aspx
    ///// 
    ///// This has been updated and tweaked to work with MVC 3 / 4 projects (it hasn't been tested with MVC 
    ///// 1 / 2 but may work there) and also based my use cases
    ///// </summary>
    //public static class MvcMockHelpers
    //{
    //    #region Mock HttpContext factories

    //    public static HttpContextBase MockHttpContext()
    //    {
    //        var context = new Mock<HttpContextBase>();
    //        var request = new Mock<HttpRequestBase>();
    //        var response = new Mock<HttpResponseBase>();
    //        var session = new Mock<HttpSessionStateBase>();
    //        var server = new Mock<HttpServerUtilityBase>();

    //        request.Setup(r => r.AppRelativeCurrentExecutionFilePath).Returns("/");
    //        request.Setup(r => r.ApplicationPath).Returns("/");

    //        response.Setup(s => s.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);
    //        response.SetupProperty(res => res.StatusCode, (int)System.Net.HttpStatusCode.OK);

    //        context.Setup(h => h.Request).Returns(request.Object);
    //        context.Setup(h => h.Response).Returns(response.Object);

    //        context.Setup(ctx => ctx.Request).Returns(request.Object);
    //        context.Setup(ctx => ctx.Response).Returns(response.Object);
    //        context.Setup(ctx => ctx.Session).Returns(session.Object);
    //        context.Setup(ctx => ctx.Server).Returns(server.Object);

    //        return context.Object;
    //    }

    //    public static HttpContextBase MockHttpContext(string url)
    //    {
    //        var context = MockHttpContext();
    //        context.Request.SetupRequestUrl(url);
    //        return context;
    //    }

    //    #endregion

    //    #region Extension methods

    //    public static void SetMockControllerContext(this Controller controller,
    //        HttpContextBase httpContext = null,
    //        RouteData routeData = null,
    //        RouteCollection routes = null)
    //    {
    //        //If values not passed then initialise
    //        routeData = routeData ?? new RouteData();
    //        routes = routes ?? RouteTable.Routes;
    //        httpContext = httpContext ?? MockHttpContext();

    //        var requestContext = new RequestContext(httpContext, routeData);
    //        var context = new ControllerContext(requestContext, controller);

    //        //Modify controller
    //        controller.Url = new UrlHelper(requestContext, routes);
    //        controller.ControllerContext = context;
    //    }

    //    public static void SetHttpMethodResult(this HttpRequestBase request, string httpMethod)
    //    {
    //        Mock.Get(request).Setup(req => req.HttpMethod).Returns(httpMethod);
    //    }

    //    public static void SetupRequestUrl(this HttpRequestBase request, string url)
    //    {
    //        if (url == null)
    //            throw new ArgumentNullException("url");

    //        if (!url.StartsWith("~/"))
    //            throw new ArgumentException("Sorry, we expect a virtual url starting with \"~/\".");

    //        var mock = Mock.Get(request);

    //        mock.Setup(req => req.QueryString).Returns(GetQueryStringParameters(url));
    //        mock.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns(GetUrlFileName(url));
    //        mock.Setup(req => req.PathInfo).Returns(string.Empty);
    //    }


    //    /// <summary>
    //    /// Facilitates unit testing of anonymouse types - taken from here:
    //    /// http://stackoverflow.com/a/5012105/761388
    //    /// </summary>
    //    public static object GetReflectedProperty(this object obj, string propertyName)
    //    {
    //        obj.ThrowIfNull("obj");
    //        propertyName.ThrowIfNull("propertyName");

    //        var property = obj.GetType().GetProperty(propertyName);

    //        if (property == null)
    //            return null;

    //        return property.GetValue(obj, null);
    //    }

    //    public static T ThrowIfNull<T>(this T value, string variableName) where T : class
    //    {
    //        if (value == null)
    //            throw new NullReferenceException(
    //                string.Format("Value is Null: {0}", variableName));

    //        return value;
    //    }

    //    #endregion

    //    #region Private

    //    static string GetUrlFileName(string url)
    //    {
    //        return (url.Contains("?"))
    //            ? url.Substring(0, url.IndexOf("?"))
    //            : url;
    //    }

    //    static NameValueCollection GetQueryStringParameters(string url)
    //    {
    //        if (url.Contains("?"))
    //        {
    //            var parameters = new NameValueCollection();

    //            var parts = url.Split("?".ToCharArray());
    //            var keys = parts[1].Split("&".ToCharArray());

    //            foreach (var key in keys)
    //            {
    //                var part = key.Split("=".ToCharArray());
    //                parameters.Add(part[0], part[1]);
    //            }

    //            return parameters;
    //        }

    //        return null;
    //    }

    //    #endregion
    //}


    //[Test]
    //Public void test()
    //{
    //     var mocks = new ContextMocks(controller);
    //     var req = controller.Request; 
    //     //do some asserts on Request object
    //}
}
