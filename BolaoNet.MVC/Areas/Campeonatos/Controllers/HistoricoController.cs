using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class HistoricoController: BaseCampeonatoAreaController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.ICampeonatoHistoricoApp _campeonatoHistoricoApp;

        #endregion

        #region Constructors/Destructors

        public HistoricoController(
            Application.Interfaces.Campeonatos.ICampeonatoHistoricoApp campeonatoHistoricoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _campeonatoHistoricoApp = campeonatoHistoricoApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {


            IList<Domain.Entities.Campeonatos.CampeonatoHistorico> list =
                _campeonatoHistoricoApp.LoadCampeoes (base.SelectedCampeonato);

            IList<ViewModels.Campeonatos.CampeonatoHistoricoViewModel> data =
                Mapper.Map<IList<Domain.Entities.Campeonatos.CampeonatoHistorico>,
                IList<ViewModels.Campeonatos.CampeonatoHistoricoViewModel>>
                (list);


            return View(data);
        }

        #endregion
    }
}