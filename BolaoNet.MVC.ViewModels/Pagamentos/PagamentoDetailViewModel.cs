using System.Collections.Generic;

namespace BolaoNet.MVC.ViewModels.Pagamentos
{
    public class PagamentoDetailViewModel
    {
        public decimal ValorTotal { get; set; }
        public int TotalPagamentos { get; set; }
        public IList<PagamentoCalculoViewModel> CalculoPremios { get; set; } = new List<PagamentoCalculoViewModel>();
        public IList<ResponsavelValorViewModel> ResponsaveisValores { get; set; } = new List<ResponsavelValorViewModel>();
        public IList<PagamentoViewModel> Pagamentos { get; set; } = new List<PagamentoViewModel>(); 
    }
}
