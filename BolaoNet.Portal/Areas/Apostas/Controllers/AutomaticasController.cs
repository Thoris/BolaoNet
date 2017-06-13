﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.Portal.Areas.Apostas.Controllers
{
    public class AutomaticasController : Controller
    {
        #region Actions

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Resultados()
        {
            Portal.ViewModel.Apostas.ApostasJogosListVO vo = new ViewModel.Apostas.ApostasJogosListVO();


            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = true,
                DataAposta = DateTime.Now,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Classificatória",
                GolsTime1 = 2,
                GolsTime2 = 2,
                Grupo = "A",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 1,
                Rodada = 1,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataAposta = DateTime.Now,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Classificatória",
                GolsTime1 = 1,
                GolsTime2 = 1,
                Grupo = "A",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 2,
                Rodada = 1,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataAposta = DateTime.Now,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Classificatória",
                GolsTime1 = 1,
                GolsTime2 = 2,
                Grupo = "B",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 3,
                Rodada = 1,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataAposta = DateTime.Now,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Classificatória",
                GolsTime1 = 2,
                GolsTime2 = 1,
                Grupo = "B",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 1,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Classificatória",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = "C",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 3,
                Rodada = 1,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Classificatória",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = "C",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 1,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });


            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Oitavas de Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 2,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Oitavas de Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 2,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Oitavas de Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 2,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Oitavas de Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 2,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });


            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Quartas de Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 3,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Quartas de Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 3,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });


            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Semi Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 4,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });
            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Semi Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 4,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });



            vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 5,
                Time1 = "Argentina",
                Time2 = "Argentina",
            }); vo.Apostas.Add(new ViewModel.Apostas.ApostaJogoEntryVO()
            {
                Automatico = null,
                DataJogo = DateTime.Now,
                Estadio = "São Paulo",
                Fase = "Final",
                GolsTime1 = null,
                GolsTime2 = null,
                Grupo = " ",
                ImageTime1 = "/Content/img/database/times/Argentina.gif",
                ImageTime2 = "/Content/img/database/times/Argentina.gif",
                IsLocked = true,
                JogoId = 4,
                Rodada = 5,
                Time1 = "Argentina",
                Time2 = "Argentina",
            });


            return View(vo);
        }

        #endregion
    }
}