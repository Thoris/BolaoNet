using AutoMapper;
using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Regras.Controllers
{
    public class BolaoRegrasController : BaseBolaoRegrasAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoRegraApp _bolaoRegraApp;

        #endregion

        #region Constructors/Destructors

        public BolaoRegrasController(
            Application.Interfaces.Boloes.IBolaoRegraApp bolaoRegraApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoRegraApp = bolaoRegraApp;
        }

        #endregion
    
        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.Boloes.BolaoRegra> list = _bolaoRegraApp.GetRegrasBolao(base.SelectedBolao);



            IList<ViewModels.Regras.BolaoRegrasViewModel> model =
                Mapper.Map<IList<Domain.Entities.Boloes.BolaoRegra>,
                IList<ViewModels.Regras.BolaoRegrasViewModel>>(list);



            return View(model);
        }

        #endregion
    }
}