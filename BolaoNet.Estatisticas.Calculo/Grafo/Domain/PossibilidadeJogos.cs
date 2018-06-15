using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class PossibilidadeJogos
    {
        #region Properties

        public IList<IIdentifier> Caminho { get; set; }
        public IDictionary<string, int> Pontos { get; set; }

        #endregion

        #region Constructors/Destructors

        public PossibilidadeJogos()
        {

        }

        #endregion

        #region Methods

        public void AddAresta(IAresta aresta)
        {

        }

        #endregion
    }
}
