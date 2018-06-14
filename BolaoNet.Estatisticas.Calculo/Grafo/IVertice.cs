using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo
{
    public interface IVertice 
    {
        IIdentifier Identifier { get; }
        IList<IAresta> Arestas { get; }

        void AddAresta(IAresta aresta);
        void ClearArestas();
    }
}
