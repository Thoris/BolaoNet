using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class GoleadasController: BaseCampeonatoAreaController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;

        #endregion

        #region Constructors/Destructors

        public GoleadasController(
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoApp = jogoApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {

            IList<Domain.Entities.Campeonatos.Jogo> list = _jogoApp.SelectGoleadas(base.SelectedCampeonato, 4);


            IList<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.Campeonatos.Jogo>,
                IList<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel>>
                (list);


            ViewModels.Campeonatos.CampeonatoJogosListViewModel model = new ViewModels.Campeonatos.CampeonatoJogosListViewModel();
            model.Jogos = data;

            return View(model);
        }

        #endregion
    }
}