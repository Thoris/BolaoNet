//#define DEBUG_SAVE_LOG_THROUGH_WEB

using BolaoNet.Domain.Interfaces.Services.Logging;
using BolaoNet.MVC.AutoMapper;
using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BolaoNet.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();

#if (DEBUG_SAVE_LOG_THROUGH_WEB)
            log4net.Config.XmlConfigurator.Configure();
            new Infra.CrossCutting.Logging.Logger().Configure("log4net.config");
#endif
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            Security.AuthenticationManagement.SetContextAuthentication(Request);

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            Server.ClearError();

            ILogging logging = DependencyResolver.Current.GetService<ILogging>();

            logging.Fatal(this, exception);
            
            Response.Redirect("~/Views/Shared/Error.cshtml");
        }
    }
}
