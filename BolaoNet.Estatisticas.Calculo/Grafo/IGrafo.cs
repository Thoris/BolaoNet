using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo
{
    public interface IGrafo
    {
        IVertice MainVertice { get; }

        IList<IVertice> Vertices { get; }

        IVertice CreateVertice(IIdentifier identifier);
        IAresta CreateAresta(IIdentifier source, IIdentifier target);

        void Clear();
        void Add(IIdentifier sourceId, IAresta aresta);
        void Add(IVertice vertice);
        void Add(IVertice vertice, IAresta aresta);
        int GetTotalVertices();
    }
}
