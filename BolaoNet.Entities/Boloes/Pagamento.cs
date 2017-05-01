using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
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
        
        public Bolao Bolao {get;set;}
        public string UserName{get;set;}
        public DateTime DataPagamento{get;set;}
        public Tipo TipoPagamento{get;set;}
        public decimal Valor{get;set;}
        public string Descricao{get;set;}

        #endregion
    }
}
