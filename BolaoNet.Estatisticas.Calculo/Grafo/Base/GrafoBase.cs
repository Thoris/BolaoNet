using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Base
{
    public abstract class GrafoBase : IGrafo
    {
        #region Variables

        protected IVertice _mainVertice;
        private IList<IVertice> _vertices;

        #endregion

        #region Properties

        public IVertice MainVertice
        {
            get { return _mainVertice; }
        }
        public IList<IVertice> Vertices
        {
            get { return _vertices; }
        }

        #endregion

        #region Constructors/Destructors

        public GrafoBase(IList<IVertice> vertices)
        {
            _vertices = vertices;
        }

        #endregion

        #region Methods

        private int SearchIdentifier(IIdentifier identifier)
        {
            if (identifier == null)
                throw new ArgumentException("identifier");

            for (int c=0; c < _vertices.Count; c++)
            {
                if (_vertices[c].Identifier.IsEqual(identifier))
                {
                    return c;
                }
            }

            return -1;
        }

        #endregion

        #region IGrafo members

        public virtual IVertice CreateVertice(IIdentifier identifier)
        {
            throw new Exception("This should be implemented.");
        }

        public virtual IAresta CreateAresta(IIdentifier source, IIdentifier target)
        {
            throw new Exception("This should be implemented.");
        }
        
        public void Clear()
        {
            _vertices.Clear();
        }

        public void Add(IVertice vertice)
        {
            int pos = SearchIdentifier(vertice.Identifier);

            if (pos != -1)
                throw new Exception("Vertice is already in the list");

            _vertices.Add(vertice);
        }

        public void Add(IIdentifier sourceId, IAresta aresta)
        {
            int pos = SearchIdentifier(sourceId);

            if (pos == -1)
                throw new Exception("Source Vertice is not found in the list");

            int posTarget = SearchIdentifier(aresta.VerticeId);

            if (posTarget == -1)
                throw new Exception("Target Vertice is not found int the list");

            for (int i = 0; i < _vertices[pos].Arestas.Count; i++)
            {
                if (_vertices[pos].Arestas[i].VerticeId.IsEqual(aresta.VerticeId))
                    throw new Exception("Aresta is already in the vertice.");
            }

            aresta.VerticeId = _vertices[posTarget].Identifier;

            _vertices[pos].AddAresta(aresta);
        }

        public void Add(IVertice vertice, IAresta aresta)
        {
            Add(vertice.Identifier, aresta);
        }

        public int GetTotalVertices()
        {
            return _vertices.Count;
        }

        
        #endregion



    }
}
