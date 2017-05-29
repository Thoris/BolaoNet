using System.Web.Mvc;

namespace BolaoNet.Portal.Areas.Pagamentos
{
    public class PagamentosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pagamentos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pagamentos_default",
                "Pagamentos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}