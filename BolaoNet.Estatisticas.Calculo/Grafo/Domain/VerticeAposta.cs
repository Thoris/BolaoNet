using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class VerticeAposta : JogoPossibilidade, IVertice
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

        public void SetPossibilidade(JogoPossibilidade possibilidade)
        {
            base.GolsTime1 = possibilidade.GolsTime1;
            base.GolsTime2 = possibilidade.GolsTime2;
            base.TotalApostas = possibilidade.TotalApostas;
        }

        public void AddAresta(IAresta aresta)
        {           
            _arestas.Add(aresta);
        }

        public void ClearArestas()
        {
            _arestas.Clear();
        }

        public static IVertice Create(IIdentifier identifier)
        {
            return new VerticeAposta(identifier);
        }

        #endregion
    }
}
