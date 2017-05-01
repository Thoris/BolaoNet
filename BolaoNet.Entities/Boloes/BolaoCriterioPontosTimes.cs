using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoCriterioPontosTimes : Base.AuditModel
    {
        #region Properties
        
        public Bolao Bolao { get; set; }
        public Entities.DadosBasicos.Time Time { get; set; }
        public int MultiploTime { get; set; }
     
        #endregion
    }
}
