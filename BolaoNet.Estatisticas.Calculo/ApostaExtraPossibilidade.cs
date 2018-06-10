using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class ApostaExtraPossibilidade
    {
        #region Properties

        public string NomeTime { get; set; }
        public IList<ApostaExtraPontos> Pontos { get; set; }
        public int TotalApostas { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraPossibilidade()
        {

        }
        public ApostaExtraPossibilidade(ApostaExtraAposta aposta)
        {
            this.TotalApostas = 1;
            this.NomeTime = aposta.NomeTime;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "";

            if (this.NomeTime != null)
                res += this.NomeTime;

            if (this.Pontos != null)
                res += " [ " + this.Pontos.Count + " ]";

            return res;
        }

        #endregion
    }
}
