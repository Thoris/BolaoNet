﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class ApostasAutomaticasController : BaseApostasAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors

        public ApostasAutomaticasController(
                Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
                Application.Interfaces.Boloes.IBolaoApp bolaoApp,
                Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
                Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
                Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
                Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
                Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            ViewModels.Apostas.ApostasAutomaticasViewModel model = new ViewModels.Apostas.ApostasAutomaticasViewModel();
            
            ViewBag.Rodadas = new SelectList(base.CampeonatoData.Rodadas);

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(ViewModels.Apostas.ApostasAutomaticasViewModel model)
        {

            ViewBag.Rodadas = new SelectList(base.CampeonatoData.Rodadas);

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            #region Tipo Aposta

            switch ((ViewModels.Apostas.ApostasAutomaticasViewModel.TipoApostaEnum) model.TipoAposta)
            { 
                case ViewModels.Apostas.ApostasAutomaticasViewModel.TipoApostaEnum.TodosJogos:

                    model.Rodada = null;
                    model.DataFinal = null;
                    model.DataInicial = null;

                    break;

                case  ViewModels.Apostas.ApostasAutomaticasViewModel.TipoApostaEnum.Rodada:

                    if (model.Rodada == null)
                    {
                        ModelState.AddModelError("", "Rodada precisa ser preenchida.");
                        return View("Index", model);
                    }

                    break;

                case  ViewModels.Apostas.ApostasAutomaticasViewModel.TipoApostaEnum.DurantePeriodo:

                    model.Rodada = null;
                    bool res = true;
                    if (model.DataInicial == null)
                    {
                        ModelState.AddModelError("", "Data inicial precisa ser preenchida.");
                        res = false;                       
                    }
                    if (model.DataFinal == null)
                    {
                        ModelState.AddModelError("", "Data Final precisa ser preenchida.");
                        res = false;                       
                    }
                    if (!res)
                    {
                        return View("Index", model);
                    }
                    if (DateTime.Compare((DateTime)model.DataFinal, (DateTime)model.DataInicial) < 0)
                    {
                        ModelState.AddModelError("", "Data Final deve ser maior que a inicial.");
                        return View("Index", model);
                    }

                    break;
            }
            #endregion

            #region Gols / Minimo / Máximo

            if (model.ValoresFixos)
            {
                bool res = true;
                if (model.ApostaTimeCasa == null)
                {
                    ModelState.AddModelError("", "Aposta do time de casa deve ser preenchido.");
                    res = false;
                }
                if (model.ApostaTimeFora == null)
                {
                    ModelState.AddModelError("", "Aposta do time de fora deve ser preenchido.");
                    res = false;
                }
                if (!res)
                {
                    return View("Index", model);
                }
            }
            else
            {
                bool res = true;
                if (model.ValorInicial == null)
                {
                    ModelState.AddModelError("", "Valor inicial de gols deve ser preenchido.");
                    res = false;
                }
                if (model.ValorFinal == null)
                {
                    ModelState.AddModelError("", "Valor final de gols deve ser preenchido.");
                    res = false;
                }
                if (!res)
                {
                    return View("Index", model);
                }
                if (model.ValorFinal < model.ValorInicial)
                {
                    ModelState.AddModelError("", "Valor inicial deve ser menor que o final.");
                    return View("Index", model);
                }
            }            

            if (model.SubstituicaoAposta == ViewModels.Apostas.ApostasAutomaticasViewModel.SubstituicaoApostaEnum.Todas ||
                model.SubstituicaoAposta == ViewModels.Apostas.ApostasAutomaticasViewModel.SubstituicaoApostaEnum.JogosNaoApostados)
            {
                model.ApostasAutomaticas = ViewModels.Apostas.ApostasAutomaticasViewModel.ApostasAutomaticasEnum.Todas;
            }
            else
            {                
                if (model.ApostasAutomaticas == null )
                {
                    ModelState.AddModelError("", "É necessário atribuir o tipo de substituição.");
                    return View("Index", model);
                }
            }

            #endregion


            Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO data =
                Mapper.Map<ViewModels.Apostas.ApostasAutomaticasViewModel,
                Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO>(model);

            data.TipoAposta = (int)model.SubstituicaoAposta;
            data.TipoAutomatico = (int)model.ApostasAutomaticas;

            _jogoUsuarioApp.InsertApostasAutomaticas(base.SelectedBolao, base.UserLogged, data);

            base.ShowMessage("Apostas inseridas com sucesso.");

            return RedirectToAction("ViewJogos");
        }

        public ActionResult ViewJogos()
        {
            return View();
        }


        #endregion
    }
}