using System.ComponentModel;

namespace BolaoNet.MVC.ViewModels.Pagamentos
{
    public class PagamentoCalculoViewModel
    {
        [DisplayName("Posição")]
        public int Pos {  get; set; }
        [DisplayName("Colocação")]
        public string Colocacao { get; set; }
        [DisplayName("Percentual%")]
        public decimal Percentage { get; set; }
        [DisplayName("Valor da premiação")]
        public decimal ValorPremiacao { get; set; }

    }
}
