using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class JogosPossibilidadesGenerator
    {
        #region Constructors/Destructors

        public JogosPossibilidadesGenerator()
        {

        }

        #endregion

        #region Methods

        public IList<PontuacaoJogos> Generate(IList<JogoInfo> jogos)
        {
            IList<PontuacaoJogos> list = new List<PontuacaoJogos>();

            for (int c = 0; c < list.Count; c++ )
            {
                for (int l = 0; l < list[c].PontosUsuarios.Count; l++)
                {
                }
            }

            return list;
        }

        #endregion
    }
}
