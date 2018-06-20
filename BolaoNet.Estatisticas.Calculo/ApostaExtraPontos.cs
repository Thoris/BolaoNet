using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class ApostaExtraPontos
    {
        #region Properties

        public string UserName { get; set; }
        public string NomeTime { get; set; }
        public int Pontos { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraPontos()
        {

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "";

            if (!string.IsNullOrEmpty(this.UserName))
                res += this.UserName + " : ";

            if (!string.IsNullOrEmpty(this.NomeTime))
                res += this.NomeTime + " - ";

            res += Pontos;

            return res;
        }

        #endregion
    }
}
