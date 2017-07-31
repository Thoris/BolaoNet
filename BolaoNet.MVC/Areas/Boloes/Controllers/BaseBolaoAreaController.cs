using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    [AuthorizeRoles(PermissionLevel.Administrador , PermissionLevel.Apostador , PermissionLevel.VisitanteBolao , PermissionLevel.GerenciadorBolao)]
    public class BaseBolaoAreaController : BaseBolaoController
    {
        #region Constructors/Destructors

        public BaseBolaoAreaController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            
        }

        #endregion

        #region Methods

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            bool bolaoIniciado = _bolaoApp.IsIniciado(base.SelectedBolao);

            base.IsBolaoIniciado = bolaoIniciado;

            if (!bolaoIniciado)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "AcessoBolao",
                    action = "BolaoNaoIniciado"
                }));
            }

        }

        #endregion
    }
}