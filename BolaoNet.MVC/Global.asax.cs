﻿using BolaoNet.MVC.AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace BolaoNet.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();


            //log4net.Config.XmlConfigurator.Configure();
            //new Infra.CrossCutting.Logging.Logger().Configure("log4net.config");
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            Security.AuthenticationManagement.SetContextAuthentication(Request);

        }
    }
}
