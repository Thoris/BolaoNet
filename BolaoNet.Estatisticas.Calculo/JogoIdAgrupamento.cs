using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class JogoIdAgrupamento
    {
        #region Properties

        public int JogoId { get; set; }
        public int Gols1 { get; set; }
        public int Gols2 { get; set; }

        #endregion

        #region Constructors/Destructors

        public JogoIdAgrupamento()
        {

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return JogoId + " : " + Gols1 + " x " + Gols2;
        }

        #endregion
    }
}
