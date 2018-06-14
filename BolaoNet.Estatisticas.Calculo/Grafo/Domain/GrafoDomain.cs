using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class GrafoDomain : IGrafo
    {
        #region Variables

        private IList<IVertice> _vertices;

        #endregion

        #region Properties
        
        public IList<IVertice> Vertices
        {
            get
            {
                return _vertices;
            }
            set
            {
                _vertices = value;
            }
        }
        
        #endregion

        #region Constructors/Destructors

        public GrafoDomain()
        {
            _vertices = new List<IVertice>();
        }

        #endregion

        #region Methods

        public IVertice CreateVertice(int jogoId, int possibilidadeId)
        {
            return VerticeAposta.Create(Identifier.Create(_vertices.Count + 1, jogoId, possibilidadeId));
        }

        public IAresta CreateAresta()
        {
            return ArestaJogo.Create();
        }

        public void Add(IVertice vertice)
        {
            for (int c=0; c < _vertices.Count; c++)
            {
                if (IsAlreadyExists(_vertices, vertice))
                    throw new Exception("Vertice is already in the list");
            }

            _vertices.Add(vertice);
        }

        private bool IsAlreadyExists(IList<IVertice> list, IVertice vertice)
        {
            for (int c=0; c < list.Count; c++)
            {
                if (list[c].Identifier.IsEqual(vertice.Identifier))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            _vertices.Clear();
        }

        public void Add(IVertice vertice, IAresta aresta)
        {
            int pos = SearchVertice(_vertices, vertice);

            if (pos == -1)
                throw new Exception("Vertice is not found");


        }
        
        private int SearchVertice(IList<IVertice> vertices, IVertice vertice)
        {
            for (int c=0; c < vertices.Count; c++)
            {
                if (vertices[c].Identifier.IsEqual(vertice.Identifier))
                {
                    return c;
                }
            }

            return -1;
        }

        public void CreateGrafo(IList<JogoInfo> jogos)
        {
            for (int c=0; c < jogos.Count; c++)
            {
                for (int i = 0; i  <jogos[c].Possibilidades.Count; i++)
                {
                    IVertice vertice = this.CreateVertice(jogos[c].JogoId, i);

                    this.Add(vertice);
                }
            }


            for (int c = 0; c < jogos.Count; c++)
            {
                for (int i = 0; i < jogos[c].Possibilidades.Count; i++)
                {
                    for (int l = c + 1; l < jogos.Count; l ++)
                    {
                        for (int x = 0; x < jogos[l].Possibilidades.Count; x++)
                        {
                            IAresta aresta = this.CreateAresta();

                            int posVertice = -1;

                             
                            //for (int u = 0; u  < _vertices.Count; u ++)
                            //{
                            //    if (_vertices[u].Identifier.)
                            //}
                            
                        }
                    }
                }
            }

        }

        #endregion


        public IVertice CreateVertice(int jogoId)
        {
            throw new NotImplementedException();
        }
    }
}
