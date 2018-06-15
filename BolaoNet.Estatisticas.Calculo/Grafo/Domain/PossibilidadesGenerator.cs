using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class PossibilidadesGenerator
    {
        #region Variables

        private IList<PossibilidadeJogos> _possibilidades;

        #endregion

        #region Methods

        public void Generate(IList<IVertice> vertices)
        {
            for (int c = 0; c < vertices.Count; c++)
            {
                for (int i = 0; i < vertices[c].Arestas.Count; i++)
                {

                }
            }
        }

        #endregion
    }
}
