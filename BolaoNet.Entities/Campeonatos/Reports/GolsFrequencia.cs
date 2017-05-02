using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos.Reports
{
    public class GolsFrequencia : Base.AuditModel
    {
        #region Properties

        public int Gols1 { get; set; }
        public int Gols2 { get; set; }
        public int Total { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public GolsFrequencia()
        {

        }

        #endregion
    }
}
