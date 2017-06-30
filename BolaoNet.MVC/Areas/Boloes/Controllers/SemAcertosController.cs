using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class SemAcertosController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors


        public SemAcertosController(
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.Campeonatos.Jogo> list = _jogoUsuarioApp.LoadSemAcertos(base.SelectedBolao);

            IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel> data =
                 Mapper.Map<IList<Domain.Entities.Campeonatos.Jogo>,
                 IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>>
                 (list);


            ViewModels.Bolao.ApostasUsuariosListViewModel model = new ViewModels.Bolao.ApostasUsuariosListViewModel();
            model.Apostas = data;

            return View(model);
        }

        #endregion

    }
    
}