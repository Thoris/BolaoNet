using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseBolaoController : BaseCampeonatoController
    {
        #region Constants

        public const string PersistNomeBolaoSelected = "NomeBolaoSelected";
        public const string PersistIsBolaoIniciado = "IsBolaoIniciado";

        #endregion

        #region Variables

        protected Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        protected Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;
            
        #endregion

        #region Properties



        #endregion

        #region Constructors/Destructors

        public BaseBolaoController (
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base 
            (
                campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp
            )
        {
            _bolaoApp = bolaoApp;
            _bolaoMembroApp = bolaoMembroApp;
            
        }

        #endregion

        #region Methods
         
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!IsCheckSelectedBolao(_bolaoMembroApp, _bolaoApp))
            {

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { 
                            controller = "UserBoloes", 
                            action = "Index",
                            area = "Users"
                        }));

                //filterContext.Result = new BolaoNet.MVC.Areas.Users.Controllers.UserBoloesController
                //    (
                //     _bolaoMembroApp, _bolaoApp, CampeonatoApp, CampeonatoFaseApp, 
                //     CampeonatoGrupoApp, CampeonatoTimeApp
                //    ).Index();                

                return;
            }
        }
        protected ActionResult DownloadStream(Stream stream, string fileType, string fileName)
        {
            return File(stream, fileType, fileName);
        }

        #endregion
    }
}