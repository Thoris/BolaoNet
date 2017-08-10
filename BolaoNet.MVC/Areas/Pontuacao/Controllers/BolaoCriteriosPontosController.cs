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

        #region Methods

        private ViewModels.Pontuacao.BolaoCriterioPontosSimulacaoListViewModel SimularApostas(IList<Domain.Entities.Boloes.BolaoCriterioPontos> pontos, int gols1, int gols2)
        {
            ViewModels.Pontuacao.BolaoCriterioPontosSimulacaoListViewModel res = new ViewModels.Pontuacao.BolaoCriterioPontosSimulacaoListViewModel();



            int pontosEmpate = 0, pontosVitoria =0, pontosDerrota = 0, pontosGanhador = 0, pontosPerdedor = 0, pontosTime1 = 0,
                pontosTime2 = 0, pontosVDE = 0, pontosErro = 0, pontosGanhadorFora = 0, pontosGanhadorDentro = 0, pontosPerdedorFora = 0, 
                pontosPerdedorDentro = 0, pontosEmpateGols = 0, pontosGolsTime1 = 0, pontosGolsTime2 = 0, pontosCheio = 0, 
                multiploTime = 0;
            bool isMultiploTime = false;

            for (int c = 0; c < pontos.Count; c++ )
            {
                switch((Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID) pontos[c].CriterioID)
                {
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio:
                        pontosCheio = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Derrota:
                        pontosDerrota = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Empate:
                        pontosEmpate = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.EmpateGols:
                        pontosEmpateGols = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Erro:
                        pontosErro = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Ganhador:
                        pontosGanhador = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorDentro:
                        pontosGanhadorDentro = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorFora:
                        pontosGanhadorFora = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime1:
                        pontosGolsTime1 = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime2:
                        pontosGolsTime2 = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Perdedor:
                        pontosPerdedor = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorDentro:
                        pontosPerdedorDentro = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorFora:
                        pontosPerdedorFora = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time1:
                        pontosTime1 = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time2:
                        pontosTime2 = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Vitoria:
                        pontosVitoria = (int)pontos[c].Pontos;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.VitoriaDerrotaEmpate:
                        pontosVDE = (int)pontos[c].Pontos;
                        break;

                }
            }

            res.GolsTime1 = gols1;
            res.GolsTime2 = gols2;

            IList<Domain.Entities.Boloes.JogoUsuario> apostas = new List<Domain.Entities.Boloes.JogoUsuario>();
            apostas.Add(new Domain.Entities.Boloes.JogoUsuario() { ApostaTime1 = 0, ApostaTime2 = 0 });
            apostas.Add(new Domain.Entities.Boloes.JogoUsuario() { ApostaTime1 = 1, ApostaTime2 = 0 });
            apostas.Add(new Domain.Entities.Boloes.JogoUsuario() { ApostaTime1 = 0, ApostaTime2 = 1 });
            apostas.Add(new Domain.Entities.Boloes.JogoUsuario() { ApostaTime1 = 1, ApostaTime2 = 1 });


            apostas = _jogoUsuarioApp.Simulate(apostas, gols1, gols2, pontosEmpate, pontosVitoria, pontosDerrota, pontosGanhador, 
                    pontosPerdedor, pontosTime1, pontosTime2, pontosVDE, pontosErro, pontosGanhadorFora, 
                    pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro, pontosEmpateGols, 
                    pontosGolsTime1, pontosGolsTime2, pontosCheio, isMultiploTime, multiploTime);

            res.Simulacao = new List<ViewModels.Pontuacao.BolaoCriterioPontosSimulacaoViewModel>();

            for (int c = 0; c < apostas.Count; c++ )
            {
                res.Simulacao.Add(new ViewModels.Pontuacao.BolaoCriterioPontosSimulacaoViewModel()
                    {
                        ApostaTime1 = (int)apostas[c].ApostaTime1,
                        ApostaTime2 = (int)apostas[c].ApostaTime2,
                        Pontos = (int)apostas[c].Pontos
                    });
            }

                return res;
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

            model.Simulacoes.Add(SimularApostas(pontos, 0, 0));
            model.Simulacoes.Add(SimularApostas(pontos, 1, 0));
            model.Simulacoes.Add(SimularApostas(pontos, 1, 1));


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