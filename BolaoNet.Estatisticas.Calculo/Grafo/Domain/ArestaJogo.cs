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

        #endregion

        #region Constructors/Destructors
        
        public ArestaJogo(IIdentifier targetId)
        {
            _verticeId = targetId;
            _apostas = new Dictionary<string, int>();
        }
         
        #endregion

        #region Methods

        public void SetPontuacao(IList<ApostaPontos> apostas)
        {
            for (int c=0; c < apostas.Count; c++)
            {                
                _apostas.Add(apostas[c].UserName, apostas[c].Pontos);
            }
        }

        public static IAresta Create(IIdentifier targetId)
        {
            return new ArestaJogo(targetId);
        }

        #endregion
    }
}
