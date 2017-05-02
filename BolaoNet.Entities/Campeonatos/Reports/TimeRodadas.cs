using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos.Reports
{
    public class TimeRodadas
    {
        #region Properties
        public int Rodada { get; set; }
        public virtual DadosBasicos.Time Time { get; set; }
        public int Posicao { get; set; }

        #endregion

        #region Constructors/Destructors

        public TimeRodadas()
        {

        }

        #endregion
    }
}
