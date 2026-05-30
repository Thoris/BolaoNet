using AutoMapper;
using BolaoNet.MVC.ViewModels.Pagamentos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Pagamentos.Controllers
{
    public class GerenciamentoController : BasePagamentoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IPagamentoApp _pagamentoApp;
        private Application.Interfaces.Boloes.IBolaoPremioApp _bolaoPremioApp;

        #endregion

        #region Constructors/Destructors

        public GerenciamentoController(            
            Application.Interfaces.Boloes.IPagamentoApp pagamentoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IBolaoPremioApp bolaoPremioApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _pagamentoApp = pagamentoApp;
            _bolaoPremioApp = bolaoPremioApp;
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

            IList<Domain.Entities.Boloes.BolaoPremio> premios =
                _bolaoPremioApp.GetPremiosBolao(base.SelectedBolao);

            IList<ViewModels.Pagamentos.PagamentoViewModel> model =
                Mapper.Map<
                IList<Domain.Entities.Boloes.Pagamento>,
                IList<ViewModels.Pagamentos.PagamentoViewModel>>                
                (list);

            PagamentoDetailViewModel data = new PagamentoDetailViewModel();
            data.TotalPagamentos = list.Count;

            for (int c = 0; c < model.Count; c++)
            {
                model[c].TipoPagamentoDescricao = GetStringFormaPagamento(model[c].PagamentoTipoID);
                data.ValorTotal += model[c].Valor.HasValue ? model[c].Valor.Value : 0;
                int pos = -1;
                for (int l = 0; l < data.ResponsaveisValores.Count; l++)
                {
                    if (data.ResponsaveisValores[l].Responsavel == model[c].Responsavel)
                    {
                        pos = l;
                        break;
                    }
                }

                if (pos == -1)
                {
                    ResponsavelValorViewModel responsavelValor = new ResponsavelValorViewModel();
                    responsavelValor.Responsavel = model[c].Responsavel;
                    responsavelValor.Valor = model[c].Valor.HasValue ? model[c].Valor.Value : 0;
                    data.ResponsaveisValores.Add(responsavelValor);
                }
                else
                {
                    data.ResponsaveisValores[pos].Valor += model[c].Valor.HasValue ? model[c].Valor.Value : 0;
                }
            }

            for (int c=0; c < premios.Count; c++)
            {
                PagamentoCalculoViewModel pagamentoCalculo = new PagamentoCalculoViewModel();
                pagamentoCalculo.Pos = premios[c].Posicao;
                pagamentoCalculo.Colocacao = premios[c].Titulo;
                switch (premios[c].Posicao)
                {
                    case 1:
                        pagamentoCalculo.Percentage = 70;
                        break;
                    case 2:
                        pagamentoCalculo.Percentage = 20;
                        break;
                    case 3:
                        pagamentoCalculo.Percentage = 9;
                        break;
                    default:
                        pagamentoCalculo.Percentage = 1;
                        break;
                }
                pagamentoCalculo.ValorPremiacao = (data.ValorTotal * pagamentoCalculo.Percentage) / 100;
                data.CalculoPremios.Add(pagamentoCalculo);
            }

            data.Pagamentos = model;
            return View(data);
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

            base.ShowMessage("Pagamento inserido com sucesso.");

            return RedirectToAction("Index");
        }
         
        [HttpGet]
        public ActionResult Delete(string nomeBolao, string userName, DateTime dataPagamento)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Domain.Entities.Boloes.Pagamento entity = 
                new Domain.Entities.Boloes.Pagamento(dataPagamento, nomeBolao, userName);                

            Domain.Entities.Boloes.Pagamento pagamentoLoaded = _pagamentoApp.Load(entity);

            _pagamentoApp.Delete(pagamentoLoaded);

            base.ShowMessage("Pagamento excluído com sucesso.");

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string nomeBolao, string userName, DateTime dataPagamento)
        {        
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
            pagamentoLoaded.Responsavel = model.Responsavel;

            base.ShowMessage("Pagamento editado com sucesso.");

            return RedirectToAction("Index");
        }

        #endregion
    }
}