using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class ExtraJogoTime
    {
        #region Properties

        public int Posicao { get; set; }
        public string NomeTime { get; set; }
        public IList<ExtraJogoTimePossibilidade> Possibilidades { get; set; }

        #endregion

        #region Constructors/Destructors

        public ExtraJogoTime()
        {
            this.Possibilidades = new List<ExtraJogoTimePossibilidade>();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "";

            res += Posicao + ". ";

            if (!string.IsNullOrEmpty (NomeTime))
            {
                res += NomeTime;
            }

            for (int c = 0; c < Possibilidades.Count; c++ )
            {
                res += "[";

                res += Possibilidades[c].JogoId.ToString() + ": ";

                if (Possibilidades[c].GanhadorTime1)
                    res += "Time 1 - Ganhador";
                else if (Possibilidades[c].GanhadorTime2)
                    res += "Time 2 - Ganhador";
                else
                    res += "Empate";
                
                res+= "]";
            }

                return res;
        }

        #endregion
    }
}
