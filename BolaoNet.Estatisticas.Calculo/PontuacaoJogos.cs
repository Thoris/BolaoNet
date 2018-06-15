using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class PontuacaoJogos
    {
        #region Properties

        public int JogoId { get; set; }
        public int Gols1 { get; set; }
        public int Gols2 { get; set; }
        public IDictionary<string, int> PontosUsuarios { get; set; }

        #endregion

        #region Constructors/Destructors

        public PontuacaoJogos()
        {

        }

        #endregion
    }
}
