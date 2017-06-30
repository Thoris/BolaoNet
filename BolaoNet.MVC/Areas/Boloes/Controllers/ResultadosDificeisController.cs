using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ResultadosDificeisController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors


        public ResultadosDificeisController(
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
            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list = _jogoUsuarioApp.LoadAcertosDificeis(base.SelectedBolao, 2);

            IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel> data =
                 Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                 IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>>
                 (list);


            ViewModels.Bolao.ApostasUsuariosListViewModel model = new ViewModels.Bolao.ApostasUsuariosListViewModel();
            model.Apostas = data;

            return View(model);

        }

        #endregion

    
    }
}