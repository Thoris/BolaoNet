﻿using AutoMapper;
using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Resultados.Controllers
{
    public class JogoResultadoController : BaseResultadosAreaController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Feed.IRssApp _rssApp;

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
            Application.Interfaces.Feed.IRssApp rssApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, 
            campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoApp = jogoApp;
            _rssApp = rssApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index(int id, string message)
        {
            Domain.Entities.Campeonatos.Jogo jogo =
                _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, (int)id));

            ViewModels.Resultados.JogoResultadoViewModel model =
                Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Resultados.JogoResultadoViewModel>
                (jogo);

            model.Mensagem = message;

            return View(model);
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