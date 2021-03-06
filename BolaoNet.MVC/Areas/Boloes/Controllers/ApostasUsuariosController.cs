﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasUsuariosController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Reports.IBolaoMembroApostasReportApp _bolaoMembroApostasReportApp;

        #endregion

        #region Constructors/Destructors


        public ApostasUsuariosController(
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Reports.IBolaoMembroApostasReportApp bolaoMembroApostasReportApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _bolaoMembroApostasReportApp = bolaoMembroApostasReportApp;
        }

        #endregion

        #region Methods

        private void SetFilterViewBags()
        {
            ViewBag.Rodadas = new SelectList(base.CampeonatoData.Rodadas);
            ViewBag.Fases = new SelectList(base.CampeonatoData.NomeFases);
            ViewBag.Grupos = new SelectList(base.CampeonatoData.NomeGrupos);
            ViewBag.Times = new SelectList(base.CampeonatoData.NomeTimes);


            IList<Domain.Entities.Boloes.BolaoMembro> membros = _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);
            ViewBag.Membros = new SelectList(membros, "UserName", "UserName", base.UserLogged.UserName);
        
        
        }
        private Domain.Entities.ValueObjects.FilterJogosVO GetFilter(ViewModels.Bolao.FilterJogosViewModel filter)
        {
            Domain.Entities.ValueObjects.FilterJogosVO res = new Domain.Entities.ValueObjects.FilterJogosVO();

            #region Verificação do Filtro
            Domain.Entities.ValueObjects.FilterJogosVO filterVO = new Domain.Entities.ValueObjects.FilterJogosVO();

            switch ((ViewModels.Bolao.FilterJogosViewModel.FilterJogoType)filter.FilterSelected)
            {
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Este_mes:

                    res.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime finalA = DateTime.Now.AddMonths(1);
                    res.DataFinal = new DateTime(finalA.Year, finalA.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Fase:

                    res.NomeFase = filter.NomeFase;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Grupo:

                    res.NomeGrupo = filter.NomeGrupo;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ontem_Hoje_Amanha:

                    res.DataInicial = DateTime.Now.AddDays(-1);
                    res.DataFinal = DateTime.Now.AddDays(1);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Periodo:

                    res.DataInicial = filter.DataInicial;
                    res.DataFinal = filter.DataFinal;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Proximo_mes:

                    DateTime inicial = DateTime.Now.AddMonths(1);
                    res.DataInicial = new DateTime(inicial.Year, inicial.Month, 1);
                    DateTime finalB = inicial.AddMonths(1);
                    res.DataFinal = new DateTime(finalB.Year, finalB.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Proximos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(7);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Rodada:

                    res.Rodada = filter.Rodada;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Time:

                    res.NomeTime = filter.NomeTime;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ultimo_Mes:

                    DateTime inicialC = DateTime.Now.AddMonths(-1);
                    res.DataInicial = new DateTime(inicialC.Year, inicialC.Month, 1);
                    DateTime finalC = inicialC.AddMonths(1);
                    res.DataFinal = new DateTime(finalC.Year, finalC.Month, 1).AddDays(-1);


                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ultimos_7_dias:

                    res.DataInicial = DateTime.Now.AddDays(-7);
                    res.DataFinal = DateTime.Now ;

                    break;

            }
            #endregion


            return res;

        }
        private IList<Domain.Entities.ValueObjects.JogoUsuarioVO> Bind(Domain.Entities.ValueObjects.FilterJogosVO filter, string userName)
        {
            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
               _jogoUsuarioApp.GetJogosUser(
               base.SelectedBolao,
               new Domain.Entities.Users.User (userName),
               filter);

            return list;
        }

        #endregion

        #region Actions

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filtrar(ViewModels.Bolao.ApostasUsuariosListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            SetFilterViewBags();

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
                Bind(GetFilter(model.Filtros), model.Filtros.UserName);


            IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>>
                (list);

            model.UserName = model.Filtros.UserName;
            model.Apostas = data;

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Index(ViewModels.Bolao.ApostasUsuariosListViewModel model)
        {
            SetFilterViewBags();

            model = new ViewModels.Bolao.ApostasUsuariosListViewModel();

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list = Bind(
                new Domain.Entities.ValueObjects.FilterJogosVO ()
                {
                    DataInicial = DateTime.Now.AddDays(-1),
                    DataFinal = DateTime.Now.AddDays(1),
                },
                base.UserLogged.UserName) ;
            

            IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                IList<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>>
                (list);

            model.Filtros.FilterSelected = (int)ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ontem_Hoje_Amanha;
            //model.Filtros.Rodada = 1;
            model.Apostas = data;
            model.UserName = base.UserLogged.UserName;

            return View(model);
        }

        public ActionResult SelectJogo(string buttonSelected, ViewModels.Bolao.ApostasUsuariosListViewModel model)
        {
            if (string.IsNullOrEmpty(buttonSelected))
                return RedirectToAction("Index");




            return RedirectToAction("Index", "ApostasJogo", new { id = buttonSelected });
        }

        public ActionResult DownloadApostas(ViewModels.Bolao.ApostasUsuariosListViewModel model)
        {
            //ASCIIEncoding ascii = new ASCIIEncoding();
            //byte[] byteArray = Encoding.UTF8.GetBytes(model.UserName);
            //byte[] asciiArray = Encoding.Convert(Encoding.UTF8, Encoding.Default, byteArray);
            //model.UserName = ascii.GetString(asciiArray);

            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(model.UserName);
            model.UserName = Encoding.UTF8.GetString(bytes);

            Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data =
                _bolaoMembroApostasReportApp.GetData(base.SelectedBolao, new Domain.Entities.Users.User (model.UserName));



            Stream streamReport = _bolaoMembroApostasReportApp.Generate(
                "gif",
                Server.MapPath("~/Content/img/database/profiles"),
                Server.MapPath("~/Content/img/database/times"), data);


            return base.DownloadStream(streamReport, "text/plain", model.UserName + ".pdf");
        }

        #endregion

    }
    
}