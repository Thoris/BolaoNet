using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class ArestaJogo :  IAresta
    {
        #region Variables

        private IIdentifier _verticeId;
        private IDictionary<string, int> _apostas;

        #endregion

        #region Properties

        public IIdentifier VerticeId
        {
            get
            {
                return _verticeId;
            }
            set
            {
                _verticeId = value;
            }
        }
        public IDictionary<string, int> Apostas
        {
            get { return _apostas; }
        }

        #endregion

        #region Constructors/Destructors
        
        public ArestaJogo(IIdentifier targetId)
        {
            _verticeId = targetId;
            _apostas = new Dictionary<string, int>();
        }
         
        #endregion

        #region Methods

        public void SetPontuacao(JogoPossibilidade apostas)
        {
            for (int c=0; c < apostas.Pontuacao.Count; c++)
            {     
                string userName = apostas.Pontuacao[c].UserName;
                int pontos = apostas.Pontuacao[c].Pontos;

                //if (_apostas.ContainsKey(userName))
                //    _apostas[userName] += pontos;

                _apostas.Add(userName, pontos);
            }
        }

        public static IAresta Create(IIdentifier targetId)
        {
            return new ArestaJogo(targetId);
        }

        #endregion
    }
}
