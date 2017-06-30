using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Pontuacao.Controllers
{
    public class BolaoCriteriosPontosController : BasePontosAreaController
    {
        #region Variables
        private Application.Interfaces.Boloes.IBolaoCriterioPontosApp _bolaoCriterioPontosApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp _bolaoCriterioPontosTimesApp;

        #endregion

        #region Constructors/Destructors

        public BolaoCriteriosPontosController(
            Application.Interfaces.Boloes.IBolaoCriterioPontosApp bolaoCriterioPontosApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base
            (
                bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, 
                campeonatoGrupoApp, campeonatoTimeApp
            )
        {
            _bolaoCriterioPontosApp = bolaoCriterioPontosApp;
            _bolaoCriterioPontosTimesApp = bolaoCriterioPontosTimesApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            ViewModels.Pontuacao.BolaoCriterioViewModel model = new ViewModels.Pontuacao.BolaoCriterioViewModel();

            IList<Domain.Entities.Boloes.BolaoCriterioPontos> pontos =
                _bolaoCriterioPontosApp.GetCriterioPontosBolao(base.SelectedBolao);


            IList<ViewModels.Pontuacao.BolaoCriterioPontosViewModel> pontosVO =
                Mapper.Map<IList<Domain.Entities.Boloes.BolaoCriterioPontos>,
                IList<ViewModels.Pontuacao.BolaoCriterioPontosViewModel>>(pontos);


            IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> times =
                _bolaoCriterioPontosTimesApp.GetCriterioPontosBolao(base.SelectedBolao);



            IList<ViewModels.Pontuacao.BolaoCriterioTimeViewModel> timesVO =
                Mapper.Map<IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes>,
                IList<ViewModels.Pontuacao.BolaoCriterioTimeViewModel>>(times);


            model.CriterioPontos = pontosVO;
            model.CriterioTimes = timesVO;

            return View(model);
        }

        #endregion
    }
}