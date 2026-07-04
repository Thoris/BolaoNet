using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasConcluidoController: BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp _bolaoCriterioPontosTimesApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosApp _bolaoCriterioPontosApp;
        private Application.Interfaces.Boloes.IBolaoAcertoTimePontoApp _bolaoAcertoTimePontoApp;
        private Application.Interfaces.EnriquecimentoDados.IMatchEventApp _matchEventApp;
        private Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp _worldCupMatchApp;

        #endregion

        #region Constructors/Destructors


        public ApostasConcluidoController(
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
            Application.Interfaces.EnriquecimentoDados.IMatchEventApp matchEventApp,
            Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp worldCupMatchApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _jogoApp = jogoApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoCriterioPontosApp = bolaoCriterioPontosApp;
            _bolaoCriterioPontosTimesApp = bolaoCriterioPontosTimesApp;
            _bolaoAcertoTimePontoApp = bolaoAcertoTimePontoApp;
            _matchEventApp = matchEventApp;
            _worldCupMatchApp = worldCupMatchApp;
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
                         
                        membros.RemoveAt(c);
                        break;
                    }
                }
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
            model.GolsTime1 = jogo.GolsTime1;
            model.GolsTime2 = jogo.GolsTime2;

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

                    evs.Insert(0, new ViewModels.Bolao.ApostasJogoConcluidoGolViewModel()
                    {
                        EventType = "Início",
                        HomeScore = 0,
                        AwayScore = 0,
                        Acertadores = new List<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>()
                    });


                    for (int l = 0; l < model.Apostas.Count; l++)
                    {
                        if (model.Apostas[l].ApostaTime1 == 0 &&
                            model.Apostas[l].ApostaTime2 == 0)
                        { 
                            evs[0].Acertadores.Add(model.Apostas[l]);
                            model.Apostas.RemoveAt(l);
                            l--;
                        }
                    }

                    for (int c=0; c < evs.Count; c++)
                    {
                        if (evs[c].Acertadores == null)
                            evs[c].Acertadores = new List<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>();

                        if (c > 0)
                        {
                            evs[c].HomeScore = evs[c - 1].HomeScore;
                            evs[c].AwayScore = evs[c - 1].AwayScore;


                            if (evs[c].IsHomeTeam)
                                evs[c].HomeScore++;
                            else
                                evs[c].AwayScore++;

                        }

                        for (int l = 0; l < model.Apostas.Count; l++)
                        {
                            if (model.Apostas[l].ApostaTime1 == evs[c].HomeScore &&
                                model.Apostas[l].ApostaTime2 == evs[c].AwayScore)
                            { 
                                evs[c].Acertadores.Add(model.Apostas[l]);
                                model.Apostas.RemoveAt(l);
                                l--;
                            }
                        }
                    }

                    model.NaoAcertadores= new List<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>();
                    for (int c=0; c < model.Apostas.Count; c++)
                    {
                        model.NaoAcertadores.Add(model.Apostas[c]);
                    }

                    model.Eventos = evs;
                }

            }


            return View(model);
        }
         
        #endregion
    }
}