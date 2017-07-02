using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Pagamentos
{
    public class PagamentoViewModel
    {
        #region Properties

        public string NomeBolao { get; set; }        
        public string UserName { get; set; }        
        public DateTime DataPagamento { get; set; }
        public int PagamentoTipoID { get; set; }
        public string TipoPagamentoDescricao { get; set; }
        public decimal? Valor { get; set; }
        public string Descricao { get; set; }

        #endregion
    }
}
