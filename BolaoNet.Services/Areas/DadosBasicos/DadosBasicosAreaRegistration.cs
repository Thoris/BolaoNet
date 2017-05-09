using System.Web.Mvc;

namespace BolaoNet.Services.Areas.DadosBasicos
{
    public class DadosBasicosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DadosBasicos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DadosBasicos_default",
                "DadosBasicos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}