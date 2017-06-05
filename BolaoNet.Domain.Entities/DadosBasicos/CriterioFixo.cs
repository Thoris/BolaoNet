using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.DadosBasicos
{
    public class CriterioFixo : Base.AuditModel
    {
        #region Properties

        [Key]
        public int CriterioId { get; set; }
        public string Descricao { get; set; }

        #endregion
    }
}
