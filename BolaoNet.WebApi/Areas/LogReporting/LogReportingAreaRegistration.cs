using System.Web.Mvc;

namespace BolaoNet.WebApi.Areas.LogReporting
{
    public class LogReportingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LogReporting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LogReporting_default",
                "LogReporting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}