using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Resultados.Controllers
{
    public class JogoResultadoController : BaseResultadosAreaController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Feed.IRssApp _rssApp;
        private Application.Interfaces.EnriquecimentoDados.IMatchEventApp _matchEventApp;
        private Application.Interfaces.EnriquecimentoDados.IMatchOrchestrationApp _matchOrchestration;
        private Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp _worldCupMatchApp;

        #endregion

        #region Constructors/Destructors

        public JogoResultadoController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Feed.IRssApp rssApp,
            Application.Interfaces.EnriquecimentoDados.IMatchOrchestrationApp matchOrchestrationApp,
            Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp worldCupMatchApp,
            Application.Interfaces.EnriquecimentoDados.IMatchEventApp matchEventApp

            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, 
            campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoApp = jogoApp;
            _rssApp = rssApp;
            _matchEventApp = matchEventApp;
            _matchOrchestration = matchOrchestrationApp;
            _worldCupMatchApp = worldCupMatchApp;

        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult> Index(int id, string message)
        {
            Domain.Entities.Campeonatos.Jogo jogo =
                _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, (int)id));

            ViewModels.Resultados.JogoResultadoViewModel model =
                Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Resultados.JogoResultadoViewModel>
                (jogo);

            model.Mensagem = message;

            model.Eventos = new List<ViewModels.Bolao.ApostasJogoConcluidoGolViewModel>();
            model.EventosAtualizados = false;
            if (jogo.ExternalId != null)
            {
                var match = _worldCupMatchApp.GetList(x => x.Id == jogo.ExternalId).FirstOrDefault();

                if (match != null && match.Status != "scheduled")
                {
                    model.ScoreAway = match.AwayScore;
                    model.ScoreHome = match.HomeScore;
                    model.Status = match.Status;

                    var events = _matchEventApp.GetByMatch(match.Id);
                    IList<ViewModels.Bolao.ApostasJogoConcluidoGolViewModel> evs =
                        Mapper.Map<IList<Domain.Entities.EnriquecimentoDados.MatchEvent>,
                        IList<ViewModels.Bolao.ApostasJogoConcluidoGolViewModel>>(events);

                    model.Eventos = evs;
                    model.EventosAtualizados = true;
                    for (int c = 0; c < model.Eventos.Count; c++)
                    {
                        if (c > 0)
                        {
                            model.Eventos[c].HomeScore = model.Eventos[c - 1].HomeScore;
                            model.Eventos[c].AwayScore = model.Eventos[c - 1].AwayScore;
                        }

                        if (model.Eventos[c].IsHomeTeam)
                            model.Eventos[c].HomeScore++;
                        else
                            model.Eventos[c].AwayScore++;
                    }
                }
            }

            if (!model.EventosAtualizados && jogo.ExternalId != null)
            {
                try
                {
                    var res = await _matchOrchestration.LoadMatch((int)jogo.ExternalId);

                    if (res != null)
                    {
                        model.ScoreAway = res.AwayScore;
                        model.ScoreHome = res.HomeScore;
                        model.Status = res.Status;
                        foreach (var item in res.Events)
                        {
                            model.Eventos.Add(new ViewModels.Bolao.ApostasJogoConcluidoGolViewModel()
                            {
                                EventType = item.EventType,
                                IsHomeTeam = item.IsHomeTeam ?? false,
                                IsOwnGoal = item.IsOwnGoal ?? false,
                                IsPenalty = item.IsPenalty ?? false,
                                Minute = item.Minute ?? 0,
                                PlayerName = item.PlayerName,
                                RawDescription = item.RawDescription,
                                TeamName = item.TeamName
                            });
                        }

                        for (int c = 0; c < model.Eventos.Count; c++)
                        {
                            if (c > 0)
                            {
                                model.Eventos[c].HomeScore = model.Eventos[c - 1].HomeScore;
                                model.Eventos[c].AwayScore = model.Eventos[c - 1].AwayScore;
                            }
                            if (model.Eventos[c].IsHomeTeam)
                                model.Eventos[c].HomeScore++;
                            else
                                model.Eventos[c].AwayScore++;
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }

            return View(model);
        }

        [HttpGet] 
        public async Task<ActionResult> SalvarEventos(int id)
        {
            try
            {
                Domain.Entities.Campeonatos.Jogo jogo =
                    _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, (int)id));

                await _matchOrchestration.UpdateMatch(id);

                ShowMessage("Eventos do jogo atualizados com sucesso.");
            }
            catch(Exception ex)
            {
                ShowErrorMessage("Erro ao atualizar os eventos do jogo: " + ex.Message);
            }

            return RedirectToAction("Index", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(ViewModels.Resultados.JogoResultadoViewModel model)
        {
            bool isError = false;

            isError = !ModelState.IsValid;
            if (model.IsDesempate == true)
            {
                if (model.GolsTime1 == model.GolsTime2)
                {
                    if (model.PenaltisTime1 == model.PenaltisTime2)
                    {
                        ModelState.AddModelError("", "Precisa haver um desempate dos penaltis.");
                        isError = true;
                    }
                }
            }

            if (isError)
            {
                Domain.Entities.Campeonatos.Jogo jogoView =
                _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, model.JogoId));

                ViewModels.Resultados.JogoResultadoViewModel modelView =
                Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Resultados.JogoResultadoViewModel>
                (jogoView);

                return View("Index", modelView);
            }
            
            Domain.Entities.Campeonatos.Jogo jogo =
                Mapper.Map<ViewModels.Resultados.JogoResultadoViewModel, Domain.Entities.Campeonatos.Jogo>
                (model);

            bool isOk = _jogoApp.InsertResult(jogo, model.GolsTime1, model.PenaltisTime1,
                model.GolsTime2, model.PenaltisTime2, model.ConfigurarJogoCorrente, base.UserLogged);

            if (!isOk)
            {
                Domain.Entities.Campeonatos.Jogo jogoView =
                    _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, model.JogoId));

                ViewModels.Resultados.JogoResultadoViewModel modelView =
                    Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Resultados.JogoResultadoViewModel>
                    (jogoView);


                base.ShowErrorMessage("Erro ao inserir o resultado do jogo.");
                

                return View("Index", modelView);
            }
            else
            {
                base.ShowMessage("Resultados do jogo inserido com sucesso.");


                Domain.Entities.Campeonatos.Jogo jogoView =
                   _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, model.JogoId));

                string title = "ID " + jogoView.JogoId + ", Data: " + jogoView.DataJogo.ToString("dd/MM/yyyy HH:mm") +
                    ", " + jogoView.NomeTime1 + " " + model.GolsTime1 + " x " + model.GolsTime2 + " " + jogoView.NomeTime2;
                string description = title + " => Fase " +
                    jogoView.NomeFase + ", Grupo: " + jogoView.NomeGrupo + ", Estádio: " + jogoView.Estadio + ", Rodada: " + jogoView.Rodada;


                //Adicionando a inserção do resultado no feed de notícias
                new Feed.Rss.FeedRepository(_rssApp).AddEntry(new Feed.Rss.EntryFeedItem()
                    {
                        CreatedBy = base.UserLogged.UserName,
                        DateAdded = DateTime.Now,
                        Description = description,
                        Title = title 
                    });

            }

            return RedirectToAction("Index", new { id = model.JogoId, message = "Jogo armazenado com sucesso" });
        }

        #endregion
    }
}