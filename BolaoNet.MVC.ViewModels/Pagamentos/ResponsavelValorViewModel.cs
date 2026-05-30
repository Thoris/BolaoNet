using System.ComponentModel;

namespace BolaoNet.MVC.ViewModels.Pagamentos
{
    public class ResponsavelValorViewModel
    {
        [DisplayName("Rsponsável")]
        public string Responsavel { get; set; }
        [DisplayName("Valor total")]
        public decimal Valor { get; set; }
        [DisplayName("Percentual%")]
        public double Percentage { get; set; }
    }
}
