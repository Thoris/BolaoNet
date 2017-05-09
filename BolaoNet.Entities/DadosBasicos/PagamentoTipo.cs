using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.DadosBasicos
{
    public class PagamentoTipo : Base.AuditModel
    {
        #region Properties

        [Key]
        public int TipoPagamento { get; set; }

        public string Descricao { get; set; }

        #endregion 
    }
}
