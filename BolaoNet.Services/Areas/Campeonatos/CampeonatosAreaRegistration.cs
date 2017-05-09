using System.Web.Mvc;

namespace BolaoNet.Services.Areas.Campeonatos
{
    public class CampeonatosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Campeonatos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Campeonatos_default",
                "Campeonatos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}