using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasJogoController: BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp _bolaoCriterioPontosTimesApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosApp _bolaoCriterioPontosApp;

        #endregion

        #region Constructors/Destructors


        public ApostasJogoController(
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosApp bolaoCriterioPontosApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _jogoApp = jogoApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoCriterioPontosApp = bolaoCriterioPontosApp;
            _bolaoCriterioPontosTimesApp = bolaoCriterioPontosTimesApp;
        }

        #endregion

        #region Methods

        public void CalcularPercentuais(ViewModels.Bolao.ApostasJogoViewModel model)
        {
            int totalTime1 = 0;
            int totalTime2 = 0;
            int totalEmpate = 0;
            int total = 0;


            for (int c=0; c < model.Apostas.Count; c++)
            {
                if (model.Apostas[c].ApostaTime1 == model.Apostas[c].ApostaTime2)
                {
                    totalEmpate++;
                }
                else if (model.Apostas[c].ApostaTime1 > model.Apostas[c].ApostaTime2)
                {
                    totalTime1++;
                }
                else
                {
                    totalTime2++;
                }

                total++;
                model.Apostas[c].TotalApostasResultado++;

                for (int i = c+1; i < model.Apostas.Count; i++)
                {                   
                    if (model.Apostas[c].ApostaTime1 == model.Apostas[i].ApostaTime1 &&
                        model.Apostas[c].ApostaTime2 == model.Apostas[i].ApostaTime2 )
                    {                        
                        model.Apostas[i].TotalApostasResultado++;
                        model.Apostas[c].TotalApostasResultado++;
                    }
                }
            }

            for (int c=0; c < model.Apostas.Count; c++)
            {
                model.Apostas[c].PercentualResultado =
                    (double)model.Apostas[c].TotalApostasResultado /
                    (double)model.Apostas.Count * (double)100;
            }

            model.TotalApostasEmpate = totalEmpate;
            model.TotalApostasTime1 = totalTime1;
            model.TotalApostasTime2 = totalTime2;
            model.PercentualEmpate = (double)totalEmpate / (double)total * (double)100;
            model.PercentualTime1 = (double)totalTime1 / (double)total * (double)100;
            model.PercentualTime2 = (double)totalTime2 / (double)total * (double)100;

        }
        private void MergeClassificacao(ViewModels.Bolao.ApostasJogoViewModel model, IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros) //, bool somaPontosJogo)
        {
            for (int c=membros.Count - 1; c >= 0; c--)
            {
                for (int i=0; i < model.Apostas.Count; i++)
                {
                    if (string.Compare (model.Apostas[i].UserName, membros[c].UserName, true) == 0)
                    {
                        model.Apostas[i].Posicao = (int)membros[c].Posicao;
                        model.Apostas[i].Nome = membros[c].FullName;
                        model.Apostas[i].TotalPontosClassificacao = (int)membros[c].TotalPontos;

                        //if (somaPontosJogo)
                        //    model.Apostas[i].TotalPontosClassificacao += model.Apostas[i].TotalApostasResultado;

                        membros.RemoveAt(c);
                        break;
                    }
                }
            }
        }
        private IList<Domain.Entities.Boloes.JogoUsuario> Simulate(IList<Domain.Entities.Boloes.JogoUsuario> apostas, string nomeTime1, string nomeTime2, IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> bolaoCriterioPontos, IList<Domain.Entities.Boloes.BolaoCriterioPontos> pontos, int gols1, int gols2)
        {
            //int pontosTotal = 0;

            int countEmpate = 0;	// Se o usuário apostou empate e o jogo deu empate
            int countVitoria = 0;	// Se o usuário apostou vitória para o time e deu vitória para o time selecionado
            int countDerrota = 0;	// Se o usuário apostou derrota para o time e deu derrota para o time selecionado
            int countGanhador = 0;	// Se acertou o time ganhador, idependente se está jogando em casa ou fora
            int countPerdedor = 0;	// Se acertou o time perdedor, idependente se está jogando em casa ou fora
            int countTime1 = 0;	// Se acertou a quantidade de gols do time 1 
            int countTime2 = 0;	// Se acertou a quantidade de gols do time 2
            int countVDE = 0;	// Se acertou se deu empate/derrota ou vitória no jogo
            int countErro = 0;	// Se errou o jogo
            int countGanhadorFora = 0;	// Se acertou que o time foi ganhador jogando fora de casa
            int countGanhadorDentro = 0;	// Se acertou que o time foi ganhador dentro de casa
            int countPerdedorFora = 0;	// Se acertou que o time foi perdedor fora de casa
            int countPerdedorDentro = 0;	// Se acertou que o time foi perdedor dentro de casa
            int countEmpateGols = 0;	// Se acertou a quantidade de gols quando ocorrer empate
            int countGolsTime1 = 0;	// Se acertou a quantidade de gols do time 1
            int countGolsTime2 = 0;	// Se acertou a quantidade de gols do time 2
            int countCheio = 0;	// Se acertou em cheio o resultado
            int multiploTime = 1;
            bool ismultiploTime = false;

            for (int c = 0; c < pontos.Count; c++)
            {
                switch ((Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)pontos[c].CriterioID)
                {
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Empate:
                        countEmpate = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Vitoria:
                       countVitoria = pontos[c].Pontos ?? 0;
                         break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Derrota:
                        countDerrota = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Ganhador:
                        countGanhador = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Perdedor:
                        countPerdedor = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time1:
                        countTime1 = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time2:
                        countTime2 = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.VitoriaDerrotaEmpate:
                        countVDE = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Erro:
                        countErro = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorFora:
                       countGanhadorFora = pontos[c].Pontos ?? 0;
                         break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorDentro:
                        countGanhadorDentro = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorFora:
                        countPerdedorFora = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorDentro:
                        countPerdedorDentro = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.EmpateGols:
                        countEmpateGols = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime1:
                        countGolsTime1 = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime2:
                        countGolsTime2 = pontos[c].Pontos ?? 0;
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio:
                        countCheio = pontos[c].Pontos ?? 0;
                        break;

                }
            }

            for (int c=0; c < bolaoCriterioPontos.Count; c++)
            {
                if (string.Compare (bolaoCriterioPontos[c].NomeTime, nomeTime1, true) == 0 ||
                    string.Compare (bolaoCriterioPontos[c].NomeTime, nomeTime2, true) == 0)
                {
                    ismultiploTime = true;
                    multiploTime = bolaoCriterioPontos[c].MultiploTime;
                }
            }

            IList<Domain.Entities.Boloes.JogoUsuario> jogos = _jogoUsuarioApp.Simulate(apostas, gols1, gols2, 
                countEmpate, countVitoria, countDerrota, countGanhador, countPerdedor, countTime1, countTime2, 
                countVDE, countErro, countGanhadorFora, countGanhadorDentro, countPerdedorFora, countPerdedorDentro, 
                countEmpateGols, countGolsTime1, countGolsTime2, countCheio, ismultiploTime, multiploTime);

            return jogos;
        }
        private void MergeSimulation(ViewModels.Bolao.ApostasJogoViewModel model)
        {
            for (int c=0; c < model.Apostas.Count; c++)
            {
                model.Apostas[c].TotalPontosClassificacao += (model.Apostas[c].Pontos ?? 0);
            }

            model.Apostas = model.Apostas.OrderByDescending(x => x.TotalPontosClassificacao).ToList();


            int lastPontos = 0;
            for (int c=0; c < model.Apostas.Count; c++)
            {
                model.Apostas[c].LastPosicao = model.Apostas[c].Posicao;
                    
                if (c == 0)
                {                    
                    model.Apostas[c].Posicao = 1;
                }
                else if (model.Apostas[c].TotalPontosClassificacao == lastPontos)
                {
                    model.Apostas[c].Posicao = model.Apostas[c - 1].Posicao;
                }
                else
                {
                    model.Apostas[c].Posicao = c + 1;
                }


                lastPontos = model.Apostas[c].TotalPontosClassificacao;
                    

                //pos = c + 1;
            }

        }
        #endregion

        #region Actions

        public ActionResult Index(int id)
        {

            Domain.Entities.Campeonatos.Jogo jogo =
                _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, id));

            ViewModels.Bolao.ApostasJogoViewModel model =
                Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Bolao.ApostasJogoViewModel>(jogo);


            IList<Domain.Entities.Boloes.JogoUsuario> apostas = 
                _jogoUsuarioApp.GetApostasJogo(base.SelectedBolao, jogo);

            IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel> list =
                Mapper.Map<IList<Domain.Entities.Boloes.JogoUsuario>, 
                IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>>(apostas);


            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);

            model.Apostas = list;

            CalcularPercentuais(model);
            MergeClassificacao(model, membros);

            model.Apostas = model.Apostas.OrderBy(x => x.Posicao).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Simular(ViewModels.Bolao.ApostasJogoViewModel modelParam)
        {
            Domain.Entities.Campeonatos.Jogo jogo =
                _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, modelParam.JogoId));

            ViewModels.Bolao.ApostasJogoViewModel model =
                Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Bolao.ApostasJogoViewModel>(jogo);


            IList<Domain.Entities.Boloes.JogoUsuario> apostas =
                _jogoUsuarioApp.GetApostasJogo(base.SelectedBolao, jogo);


            IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> bolaoCriterioPontosTimes =
                _bolaoCriterioPontosTimesApp.GetCriterioPontosBolao(base.SelectedBolao);

            IList<Domain.Entities.Boloes.BolaoCriterioPontos> bolaoCriterioPontos =
                _bolaoCriterioPontosApp.GetCriterioPontosBolao(base.SelectedBolao);

            apostas = Simulate(apostas, jogo.NomeTime1, jogo.NomeTime2,  
                bolaoCriterioPontosTimes, bolaoCriterioPontos, modelParam.SimulacaoGols1, modelParam.SimulacaoGols2);
            

            IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel> list =
                Mapper.Map<IList<Domain.Entities.Boloes.JogoUsuario>,
                IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>>(apostas);


            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);

            model.Apostas = list;

            CalcularPercentuais(model);
            MergeClassificacao(model, membros);
            MergeSimulation(model);


            model.Apostas = model.Apostas.OrderBy(x => x.Posicao).ToList();



            return View("Index", model);
        }

        #endregion
    }
}