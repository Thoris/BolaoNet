using System;
using System.Collections.Generic;
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

            LoadCampeonatoData();
        }

        #endregion

        #region Methods

        public bool CheckSelectedBolao()
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
                    LoadCampeonatoData();

                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (CheckSelectedBolao())
            {
                //SetDefaultCookies();

                RouteValueDictionary route = new RouteValueDictionary(new
                {
                    Area = "Users",
                    Controller = "AccountHome",
                    Action = "Profile",
                });

                filterContext.Result = new RedirectToRouteResult(route);
                return;
            }
        }

        #endregion
    }
}