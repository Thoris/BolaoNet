using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.DadosBasicos
{
    public class PagamentoTipo : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 0)]
        public int TipoPagamento { get; set; }

        public string Descricao { get; set; }

        #endregion 
    }
}
