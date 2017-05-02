using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes.Simulation
{
    public class JogoUsuarioPosicao : JogoUsuario
    {
        #region Properties

        public int Posicao { get; set; }
        public int TotalPontos { get; set; }
        public int LastPosicao { get; set; }
        public int LastPontos { get; set; }
        public int LastApostaPontos { get; set; }

        #endregion

        #region Constructors/Destructors

        public JogoUsuarioPosicao()
        {

        }

        #endregion
    }
}
