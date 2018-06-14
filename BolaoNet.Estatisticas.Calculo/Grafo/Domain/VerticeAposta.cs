using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class VerticeAposta : IVertice
    {
        #region Variables

        private IList<IAresta> _arestas;
        private IIdentifier _id;

        #endregion

        #region Properties

        public IIdentifier Identifier
        {
            get { return _id; }
        }
        public IList<IAresta> Arestas
        {
            get { return _arestas; }
        }

        #endregion

        #region Constructors/Destructors

        public VerticeAposta(IIdentifier identifier)
        {
            _id = identifier;
            _arestas = new List<IAresta>();
        } 

        #endregion

        #region Methods

        public void AddAresta(IAresta aresta)
        {
            for (int c=0; c < _arestas.Count;c ++)
            {
                if (_arestas[c].VerticeId.IsEqual(aresta.VerticeId))
                {
                    throw new Exception("Aresta is already in the list");
                }
            }

            _arestas.Add(aresta);
        }

        public void ClearArestas()
        {
            _arestas.Clear();
        }

        public static VerticeAposta Create(IIdentifier identifier)
        {
            return new VerticeAposta(identifier);
        }

        #endregion
    }
}
