using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class ApostaExtraAposta
    {
        #region Properties

        public string UserName { get; set; }
        public string NomeTime { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraAposta()
        {

        }
        public ApostaExtraAposta(Domain.Entities.Boloes.ApostaExtraUsuario aposta)
        {
            this.UserName = aposta.UserName;
            this.NomeTime = aposta.NomeTime;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "";

            if (!string.IsNullOrEmpty (this.UserName))
                res += this.UserName + " : ";

            if (!string.IsNullOrEmpty(this.NomeTime))
                res += this.NomeTime;

            return res;
        }

        #endregion
    }
}
