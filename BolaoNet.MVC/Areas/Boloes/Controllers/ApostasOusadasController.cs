using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasOusadasController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors

        public ApostasOusadasController(
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
            var list = _jogoUsuarioApp.LoadApostasOusadas(base.SelectedBolao, 1);

            IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel> data =
                 Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                 IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>>
                 (list);


            var model = new ViewModels.Bolao.ApostasUsuariosListViewModel();
            model.Apostas = data;

            return View(model);
        }

        #endregion
    }
}
