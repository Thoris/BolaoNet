using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoCriterioPontosTimes : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order=0)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order=1)]
        public string NomeTime { get; set; }
        [ForeignKey("NomeTime")]
        public virtual Entities.DadosBasicos.Time Time { get; set; }

        public int MultiploTime { get; set; }
     
        #endregion
        
        #region Constructors/Destructors

        public BolaoCriterioPontosTimes()
        {

        }

        #endregion
    }
}
