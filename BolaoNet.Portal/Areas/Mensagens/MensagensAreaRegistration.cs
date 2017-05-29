﻿using System.Web.Mvc;

namespace BolaoNet.Portal.Areas.Mensagens
{
    public class MensagensAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mensagens";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Mensagens_default",
                "Mensagens/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}