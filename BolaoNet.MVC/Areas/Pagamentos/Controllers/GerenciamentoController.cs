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

        #region Methods

        private string GetStringFormaPagamento(int id)
        {
            switch(id)
            {
                case 1:
                    return "Dinheiro";
                case 2:
                    return "Cheque";
                case 3:
                    return "Depósito";
                case 4:
                    return "Outro";
            }
            return "";
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


            for (int c = 0; c < model.Count; c++ )
            {
                model[c].TipoPagamentoDescricao = GetStringFormaPagamento(model[c].PagamentoTipoID);
            }

                return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            IList<Domain.Entities.Boloes.BolaoMembro> membros =
                _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);

            ViewBag.Membros = membros;

            ViewModels.Pagamentos.PagamentoViewModel model = new ViewModels.Pagamentos.PagamentoViewModel();

            model.NomeBolao = base.SelectedNomeBolao;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.Pagamentos.PagamentoViewModel model)
        {
            bool invalid = false;
            Domain.Entities.Boloes.Pagamento entity = null;             
            
            if (!ModelState.IsValid)
            {
                invalid = true;
            }
            else
            {
                
                entity =             
                    Mapper.Map<ViewModels.Pagamentos.PagamentoViewModel, 
                    Domain.Entities.Boloes.Pagamento>(model);

                if (_pagamentoApp.Load(entity) != null)
                {
                    ModelState.AddModelError("", "Pagamento do usuário já existe.");
                    invalid = true;
                }
            }


            if (invalid)
            {

                IList<Domain.Entities.Boloes.BolaoMembro> membros =
               _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);

                ViewBag.Membros = membros;

                return View("Create", model);
            }




            _pagamentoApp.Insert(entity);


            return RedirectToAction("Index");
        }

        //[ValidateAntiForgeryToken]
        [HttpGet]
        public ActionResult Delete(string nomeBolao, string userName, DateTime dataPagamento)
        //public ActionResult Delete (ViewModels.Pagamentos.PagamentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Domain.Entities.Boloes.Pagamento entity = 
                new Domain.Entities.Boloes.Pagamento(dataPagamento, nomeBolao, userName);
                //Mapper.Map<ViewModels.Pagamentos.PagamentoViewModel,
                //Domain.Entities.Boloes.Pagamento>(model);


            Domain.Entities.Boloes.Pagamento pagamentoLoaded = _pagamentoApp.Load(entity);


            _pagamentoApp.Delete(pagamentoLoaded);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string nomeBolao, string userName, DateTime dataPagamento)
        //public ActionResult Edit(ViewModels.Pagamentos.PagamentoViewModel model)
        {
            //ViewModels.Pagamentos.PagamentoViewModel model = new ViewModels.Pagamentos.PagamentoViewModel();

            Domain.Entities.Boloes.Pagamento entry = 
                new Domain.Entities.Boloes.Pagamento(dataPagamento, nomeBolao, userName);

             Domain.Entities.Boloes.Pagamento entryLoaded = 
                 _pagamentoApp.Load(entry);


             ViewModels.Pagamentos.PagamentoViewModel model =
                Mapper.Map<Domain.Entities.Boloes.Pagamento, ViewModels.Pagamentos.PagamentoViewModel>
                (entryLoaded);
            

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModels.Pagamentos.PagamentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", model);
            }

            Domain.Entities.Boloes.Pagamento entity =
                Mapper.Map<ViewModels.Pagamentos.PagamentoViewModel,
                Domain.Entities.Boloes.Pagamento>(model);


            Domain.Entities.Boloes.Pagamento pagamentoLoaded = _pagamentoApp.Load(entity);

            pagamentoLoaded.Valor = model.Valor;
            pagamentoLoaded.PagamentoTipoID = model.PagamentoTipoID;
            pagamentoLoaded.Descricao = model.Descricao;


            return RedirectToAction("Index");
        }

        #endregion
    }
}