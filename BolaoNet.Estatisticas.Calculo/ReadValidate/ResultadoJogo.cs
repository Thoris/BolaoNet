using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.ReadValidate
{
    public class ResultadoJogo
    {
        #region Properties

        public int Index { get; set; }
        public int PossibilidadeId { get; set; }
        public int JogoId { get; set; }
        public int Gols1 { get; set; }
        public int Gols2 { get; set; }

        #endregion
    }
}
