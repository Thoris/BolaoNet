using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class ExtraJogoTimePossibilidade
    {
        #region Properties

        public int JogoId { get; set; }
        public bool GanhadorTime1 { get; set; }
        public bool GanhadorTime2 { get; set; } 
        
        #endregion

        #region Methods

        public override string ToString()
        {
            string res = JogoId.ToString() + ": ";

            if (GanhadorTime1)
                res += "Time 1 - Ganhador";
            else if (GanhadorTime2)
                res += "Time 2 - Ganhador";
            else
                res += "Empate";

            return base.ToString();
        }

        #endregion
    }
}
