using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Resultados
{
    public class ResultadosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Resultados";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Resultados_default",
                "Resultados/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}