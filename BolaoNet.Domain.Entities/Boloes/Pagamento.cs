using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class Pagamento : Base.AuditModel
    {
        #region Enumerations
        
        public enum Tipo
        {
            Dinheiro = 1,
            Cheque = 2,
            Deposito = 3,

        }

        #endregion

        #region Properties

        
        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao {get;set;}

        [Key, Column(Order = 2)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }

        [Key, Column(Order = 3)]
        public DateTime DataPagamento { get; set; }

        public int PagamentoTipoID { get; set; }
        [ForeignKey("PagamentoTipoID")]
        public virtual DadosBasicos.PagamentoTipo PagamentoTipo { get; set; }

        //public Tipo TipoPagamento{get;set;}
        public decimal ? Valor{get;set;}
        public string Descricao{get;set;}

        #endregion
        
        #region Constructors/Destructors

        public Pagamento (DateTime dataPagamento, string nomeBolao, string userName)
        {
            this.DataPagamento = dataPagamento;
            this.NomeBolao = nomeBolao;
            this.UserName = userName;
        }
        public Pagamento()
        {

        }

        #endregion
    }
}
