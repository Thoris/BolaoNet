using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class BolaoHistoricoController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoHistoricoApp _bolaoHistoricoApp;
        
        #endregion

        #region Constructors/Destructors


        public BolaoHistoricoController(
            Application.Interfaces.Boloes.IBolaoHistoricoApp bolaoHistoricoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoHistoricoApp = bolaoHistoricoApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            MVC.ViewModels.Bolao.BolaoHistoricoListViewModel model = new ViewModels.Bolao.BolaoHistoricoListViewModel();

            model.ListYears = _bolaoHistoricoApp.GetYearsFromBolao(base.SelectedBolao);
            ViewBag.Years = model.ListYears;

            return View(model);
        }
        [HttpPost]
        public ActionResult Index( MVC.ViewModels.Bolao.BolaoHistoricoListViewModel model)
        {

            model.ListYears = _bolaoHistoricoApp.GetYearsFromBolao(base.SelectedBolao);
            ViewBag.Years = model.ListYears;

 
                IList<Domain.Entities.Boloes.BolaoHistorico> list = 
                    _bolaoHistoricoApp.GetListFromBolao(base.SelectedBolao, model.SelectedYear);

                model.Classificacao = Mapper.Map<IList<Domain.Entities.Boloes.BolaoHistorico>,
                    IList<ViewModels.Bolao.BolaoHistoricoViewModel>>(list);
 

            return View(model);
        }
        
        #endregion
    
    }
}