using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Pagamentos.Controllers
{
    public class GerenciamentoController : BasePagamentoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IPagamentoApp _pagamentoApp;

        #endregion

        #region Constructors/Destructors

        public GerenciamentoController(
            Application.Interfaces.Boloes.IPagamentoApp pagamentoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _pagamentoApp = pagamentoApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            IList<Domain.Entities.Boloes.Pagamento> list =
                _pagamentoApp.GetPagamentosBolao(base.SelectedBolao);


            IList<ViewModels.Pagamentos.PagamentoViewModel> model =
                Mapper.Map<
                IList<Domain.Entities.Boloes.Pagamento >,
                IList<ViewModels.Pagamentos.PagamentoViewModel>>                
                (list);


            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.Pagamentos.PagamentoViewModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete (ViewModels.Pagamentos.PagamentoViewModel model)
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string nomeBolao, string userName, DateTime dataPagamento)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModels.Pagamentos.PagamentoViewModel model)
        {
            return RedirectToAction("Index");
        }

        #endregion
    }
}