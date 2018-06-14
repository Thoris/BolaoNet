using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo
{
    public interface IGrafo
    {
        IList<IVertice> Vertices { get; set; }

        IVertice CreateVertice(int jogoId);
        IAresta CreateAresta();

        void Clear();
        void Add(IVertice vertice);
        void Add(IVertice vertice, IAresta aresta);
    }
}
