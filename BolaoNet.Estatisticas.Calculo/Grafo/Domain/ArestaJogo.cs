using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class ArestaJogo : IAresta
    {
        #region Variables

        private IIdentifier _verticeId;
        private IList<ApostaPontos> _apostas;

        #endregion

        #region Properties

        public IIdentifier VerticeId
        {
            get
            {
                return _verticeId;
            }             
        }

        #endregion

        #region Constructors/Destructors
         
        public ArestaJogo(JogoPossibilidade possibilidade)
        {
            _apostas = possibilidade.Pontuacao;
             
        }

        #endregion

        #region Methods

        public static ArestaJogo Create()
        {
            return new ArestaJogo(null);
        }

        #endregion
    }
}
