using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class BolaoClassificacaoController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;

        #endregion

        #region Constructors/Destructors


        public BolaoClassificacaoController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> list =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);


            IList<ViewModels.Bolao.ClassificacaoViewModel> model =
                Mapper.Map<IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>, IList<ViewModels.Bolao.ClassificacaoViewModel>>
                (list);


            return View(model);
        }

        #endregion
    }
}