using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Pagamentos
{
    public class PagamentoViewModel
    {
        #region Properties

        public string NomeBolao { get; set; }
 
        [DisplayName("Usuário")]
        [Required(ErrorMessage="O campo usuário precisa ser preenchido.")]
        public string UserName { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "O campo Data de Pagamento precisa ser preenchido.")]
        [DataType(DataType.Date, ErrorMessage = "O campo precisa ser uma data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Pagamento")]
        public DateTime ? DataPagamento { get; set; }

        [DisplayName("Forma de pagamento")]
        public int PagamentoTipoID { get; set; }

        [DisplayName("Forma de pagamento")]
        public string TipoPagamentoDescricao { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "O campo precisa ser um valor decimal")]        
        [DisplayName("Valor pago")]        
        public decimal? Valor { get; set; }

        [DisplayName("Descrição")]        
        public string Descricao { get; set; }

        #endregion
    }
}
