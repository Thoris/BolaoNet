using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Pontuacao
{
    public class PontuacaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pontuacao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pontuacao_default",
                "Pontuacao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}