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
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

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
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp
            )
            : base
            (
                bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, 
                campeonatoGrupoApp, campeonatoTimeApp
            )
        {
            _bolaoCriterioPontosApp = bolaoCriterioPontosApp;
            _bolaoCriterioPontosTimesApp = bolaoCriterioPontosTimesApp;
            _jogoUsuarioApp = jogoUsuarioApp;

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

            model.Simulacoes = new List<ViewModels.Pontuacao.BolaoCriterioPontosSimulacaoListViewModel>();




            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(ViewModels.Pontuacao.BolaoCriterioViewModel model)
        {
            IList<Domain.Entities.Boloes.BolaoCriterioPontos> pontos =
              Mapper.Map<IList<ViewModels.Pontuacao.BolaoCriterioPontosViewModel>,
              IList<Domain.Entities.Boloes.BolaoCriterioPontos>>(model.CriterioPontos);


            IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> times =
                Mapper.Map<IList<ViewModels.Pontuacao.BolaoCriterioTimeViewModel>,
                IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes>>(model.CriterioTimes);


            for (int c = 0; c < pontos.Count;c++ )
            {
                Domain.Entities.Boloes.BolaoCriterioPontos pontosEntry = _bolaoCriterioPontosApp.Load(pontos[c]);

                if (pontosEntry == null)
                    _bolaoCriterioPontosApp.Insert(pontos[c]);
                else
                {
                    pontosEntry.Pontos = pontos[c].Pontos;
                    _bolaoCriterioPontosApp.Update(pontosEntry);
                }
            }


            for (int c = 0; c < times.Count;c ++ )
            {
                Domain.Entities.Boloes.BolaoCriterioPontosTimes timesEntry = _bolaoCriterioPontosTimesApp.Load(times[c]);

                if (timesEntry == null)
                    _bolaoCriterioPontosApp.Insert(pontos[c]);
                else
                {
                    timesEntry.MultiploTime = times[c].MultiploTime;
                    _bolaoCriterioPontosTimesApp.Update(timesEntry);
                }
            }

            base.ShowMessage("Pontuação atualizada com sucesso");

                return RedirectToAction("Index");
        }

        #endregion
    }
}