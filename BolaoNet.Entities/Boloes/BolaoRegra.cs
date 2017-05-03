using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoRegra : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order=0)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order=1)]
        public int RegraID { get; set; }

        public string Descricao { get; set; }

        #endregion
    }
}
