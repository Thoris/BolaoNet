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

        public bool IsCheckSelectedBolao()
        {
            if (string.IsNullOrEmpty(base.SelectedNomeBolao))
            {
                IList<Domain.Entities.Boloes.BolaoMembro> list =
                    _bolaoMembroApp.GetListBolaoInUsers(base.UserLogged);

                if (list.Count == 1)
                {
                    this.SelectedNomeBolao = list[0].NomeBolao;

                    Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(base.SelectedBolao);

                    this.SelectedNomeCampeonato = bolaoLoaded.NomeCampeonato;
                    //LoadCampeonatoData();

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!IsCheckSelectedBolao())
            {
                
                //RouteValueDictionary route = new RouteValueDictionary(new
                //{
                //    Area = "Users",
                //    Controller = "AccountHome",
                //    Action = "Profile",
                //});

                //filterContext.Result = new RedirectToRouteResult(route);

                filterContext.Result = new BolaoNet.MVC.Areas.Users.Controllers.UserBoloesController
                    (
                     _bolaoMembroApp, _bolaoApp, CampeonatoApp, CampeonatoFaseApp, 
                     CampeonatoGrupoApp, CampeonatoTimeApp
                    ).Index();                

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