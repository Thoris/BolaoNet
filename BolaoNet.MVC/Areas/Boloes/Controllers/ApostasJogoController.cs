using AutoMapper;
using BolaoNet.Domain.Entities.Campeonatos;
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
        private Application.Interfaces.Boloes.IBolaoAcertoTimePontoApp _bolaoAcertoTimePontoApp;
        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;
        private Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp _worldCupMatchApp;
        private Application.Interfaces.EnriquecimentoDados.IMatchEventApp _matchEventApp;

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
            Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp,
            Application.Interfaces.Boloes.IBolaoAcertoTimePontoApp bolaoAcertoTimePontoApp,
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp,
            Application.Interfaces.Boloes.IApostaExtraUsuarioApp apostaExtraUsuarioApp,
            Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp worldCupMatchApp,
            Application.Interfaces.EnriquecimentoDados.IMatchEventApp matchEventApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _jogoApp = jogoApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoCriterioPontosApp = bolaoCriterioPontosApp;
            _bolaoCriterioPontosTimesApp = bolaoCriterioPontosTimesApp;
            _bolaoAcertoTimePontoApp = bolaoAcertoTimePontoApp;
            _apostaExtraApp = apostaExtraApp;
            _apostaExtraUsuarioApp = apostaExtraUsuarioApp;
            _worldCupMatchApp = worldCupMatchApp;
            _matchEventApp = matchEventApp;
        }

        #endregion

        #region Methods

        private bool GetListPosicao(
            IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> usuarios, 
            int posicao1,
            int posicao2,
            out IList<Domain.Entities.Boloes.ApostaExtraUsuario> res1,
            out IList<Domain.Entities.Boloes.ApostaExtraUsuario> res2)
        {
            res1 = new List<Domain.Entities.Boloes.ApostaExtraUsuario>();
            res2 = new List<Domain.Entities.Boloes.ApostaExtraUsuario>();
            for (int c=0; c < usuarios.Count; c++)
            {
                for (int i=0; i < usuarios[c].Count; i++)
                {
                    if (usuarios[c][i].Posicao == posicao1)
                    {
                        res1.Add(usuarios[c][i]);
                    }
                    else if (usuarios[c][i].Posicao == posicao2)
                    {
                        res2.Add(usuarios[c][i]);
                    }
                }
            }
            return  res1.Count > 0 || res2.Count > 0;
        }

        private int GetPontos(IList<Domain.Entities.Boloes.ApostaExtra> apostasExtras, int posicao)
        {
            for (int c=0; c < apostasExtras.Count; c++)
            {
                if (apostasExtras[c].Posicao == posicao)
                    return apostasExtras[c].TotalPontos ?? 0;
            }
            return 0;
        }

        private void CalcularApostasExtrasPosicao(
            ViewModels.Bolao.ApostasJogoViewModel model,
            IList<Domain.Entities.Boloes.ApostaExtra> apostasExtras,
            IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> usuarios, 
            int posicao1, 
            int posicao2,
            int golsTime1, 
            int golsTime2,
            int timeVencedorFinal)
        {
            IList<Domain.Entities.Boloes.ApostaExtraUsuario> res1;
            IList<Domain.Entities.Boloes.ApostaExtraUsuario> res2;
            var extras = GetListPosicao(usuarios, posicao1, posicao2, out res1, out res2);

            if (!extras)
                return;

            int pontos1 = GetPontos(apostasExtras, posicao1);
            int pontos2 = GetPontos(apostasExtras, posicao2);

            string nomeTime1 = model.NomeTime1;
            string nomeTime2 = model.NomeTime2;

            if (golsTime1 > golsTime2)
            {
                nomeTime1 = model.NomeTime1;
                nomeTime2 = model.NomeTime2;
            }
            else if (golsTime1 < golsTime2)
            {
                nomeTime1 = model.NomeTime2;
                nomeTime2 = model.NomeTime1;
            }
            else
            {
                if (timeVencedorFinal == 2)
                {
                    nomeTime1 = model.NomeTime2;
                    nomeTime2 = model.NomeTime1;
                }
                else
                {
                    nomeTime1 = model.NomeTime1;
                    nomeTime2 = model.NomeTime2;
                }
            }

            for (int c= res1.Count-1; c >= 0; c-- ) 
            {
                if (string.Compare(res1[c].NomeTime, nomeTime1, true) != 0)
                {
                    res1.RemoveAt(c);
                }
            }
            for (int c = res2.Count - 1; c >= 0; c--)
            {
                if (string.Compare(res2[c].NomeTime, nomeTime2, true) != 0)
                {
                    res2.RemoveAt(c);
                }
            }
            for (int c=0; c < model.Apostas.Count; c++)
            {
                if (res1.Count == 0 && res2.Count == 0)
                {
                    break;
                }
                for (int l = 0; l < res1.Count; l++)
                {
                    //if (string.Compare(model.Apostas[c].UserName, res1[l].UserName, true) == 0)
                    if (string.Equals(
                            model.Apostas[c].UserName?.Trim(),
                            res1[l].UserName?.Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    {
                        model.Apostas[c].PontosAcertoTime = model.Apostas[c].PontosAcertoTime ?? 0;
                        model.Apostas[c].PontosAcertoTime += pontos1;
                        res1.RemoveAt(l);
                        break;
                    }
                }
                for (int l = 0; l < res2.Count; l++)
                {
                    //if (string.Compare(model.Apostas[c].UserName, res2[l].UserName, true) == 0)
                    if (string.Equals(
                        model.Apostas[c].UserName?.Trim(),
                        res2[l].UserName?.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                    {
                        model.Apostas[c].PontosAcertoTime = model.Apostas[c].PontosAcertoTime ?? 0;
                        model.Apostas[c].PontosAcertoTime += pontos2;
                        res2.RemoveAt(l);
                        break;
                    }
                }
            }
        }

        private void CalcularApostasExtras(ViewModels.Bolao.ApostasJogoViewModel model, int golsTime1, int golsTime2, int timeVencedorFinal) 
        {
            //Se estiver na fase final
            if (string.Compare(model.NomeFase, CampeonatoFase.FaseFinal, true) == 0)
            {

                IList<Domain.Entities.Boloes.ApostaExtra> apostasExtras =
                    _apostaExtraApp.GetApostasBolao(this.SelectedBolao);

                IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> usuariosAgrupado =
                    _apostaExtraUsuarioApp.GetApostasBolaoAgrupado(this.SelectedBolao);

                //Se for o jogo final
                if (model.PendenteTime1Ganhador)
                {
                    CalcularApostasExtrasPosicao(model, apostasExtras, usuariosAgrupado, 1, 2, golsTime1, golsTime2, timeVencedorFinal);
                }
                //Se for disputa de terceiro lugar
                else
                {
                    CalcularApostasExtrasPosicao(model, apostasExtras, usuariosAgrupado, 3, 4, golsTime1, golsTime2, timeVencedorFinal);
                }
            }
        }
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
            for (int c=membros.Count-1; c >= 0; c--)
            {
                for (int i=0; i < model.Apostas.Count; i++)
                {
                    //if (string.Compare (model.Apostas[i].UserName, membros[c].UserName, true) == 0)
                    if (string.Equals(
                            model.Apostas[i].UserName?.Trim(),
                            membros[c].UserName?.Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    {
                        model.Apostas[i].Posicao = (int)membros[c].Posicao;
                        model.Apostas[i].Nome = membros[c].FullName;
                        model.Apostas[i].TotalPontosClassificacao = (int)membros[c].TotalPontos;
                         
                        membros.RemoveAt(c);
                        break;
                    }
                }
            }

        }
        private IList<Domain.Entities.Boloes.JogoUsuario> Simulate(IList<Domain.Entities.Boloes.JogoUsuario> apostas, string nomeTime1, string nomeTime2, int pontosAcertoTime, IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> bolaoCriterioPontos, IList<Domain.Entities.Boloes.BolaoCriterioPontos> pontos, int gols1, int gols2)
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
            int countPontosAcertoTime = pontosAcertoTime;
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
                nomeTime1, nomeTime2, countEmpate, countVitoria, countDerrota, countGanhador, countPerdedor, countTime1, countTime2, 
                countVDE, countErro, countGanhadorFora, countGanhadorDentro, countPerdedorFora, countPerdedorDentro, 
                countEmpateGols, countGolsTime1, countGolsTime2, countCheio, countPontosAcertoTime, ismultiploTime, multiploTime);

            return jogos;
        }
        private void MergeSimulation(ViewModels.Bolao.ApostasJogoViewModel model)
        {
            for (int c=0; c < model.Apostas.Count; c++)
            {
                model.Apostas[c].TotalPontosClassificacao += (model.Apostas[c].Pontos ?? 0) + (model.Apostas[c].PontosAcertoTime ?? 0);
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

            if (jogo.ExternalId != null)
            {
                var match = _worldCupMatchApp.GetList(x => x.Id == jogo.ExternalId).FirstOrDefault();

                if (match != null)
                {
                    var events = _matchEventApp.GetByMatch(match.Id);
                    IList<ViewModels.Bolao.ApostasJogoConcluidoGolViewModel> evs =
                        Mapper.Map<IList<Domain.Entities.EnriquecimentoDados.MatchEvent>,
                        IList<ViewModels.Bolao.ApostasJogoConcluidoGolViewModel>>(events);

                    for (int c = 0; c < evs.Count; c++)
                    {
                        if (c > 0)
                        {
                            evs[c].HomeScore = evs[c - 1].HomeScore;
                            evs[c].AwayScore = evs[c - 1].AwayScore;
                        }

                        if (evs[c].IsHomeTeam)
                            evs[c].HomeScore++;
                        else
                            evs[c].AwayScore++;

                    }
                    model.Eventos = evs;
                }
            }
            
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

            Domain.Entities.Boloes.BolaoAcertoTimePonto acertoTimePonto =
                _bolaoAcertoTimePontoApp.GetByJogoId(base.SelectedBolao, modelParam.JogoId);

            int pontosAcertoTime = 0;
            if (acertoTimePonto != null)
                pontosAcertoTime = acertoTimePonto.Pontos;

            apostas = Simulate(apostas, jogo.NomeTime1, jogo.NomeTime2, pontosAcertoTime,
                bolaoCriterioPontosTimes, bolaoCriterioPontos, modelParam.SimulacaoGols1, modelParam.SimulacaoGols2);
            
            IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel> list =
                Mapper.Map<IList<Domain.Entities.Boloes.JogoUsuario>,
                IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>>(apostas);

            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);

            model.Apostas = list;

            CalcularApostasExtras(model, modelParam.SimulacaoGols1, modelParam.SimulacaoGols2, modelParam.TimeVencedorFinal);
            CalcularPercentuais(model);
            MergeClassificacao(model, membros);
            MergeSimulation(model);

            model.Apostas = model.Apostas.OrderBy(x => x.Posicao).ToList();

            return View("Index", model);
        }

        #endregion
    }
}