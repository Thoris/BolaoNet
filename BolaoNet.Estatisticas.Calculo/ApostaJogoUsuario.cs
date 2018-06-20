using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class ApostaJogoUsuario
    {
        #region Properties

        public string UserName { get; set; }
        public int ApostaTime1 { get; set; }
        public int ApostaTime2 { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaJogoUsuario()
        {
        }
        public ApostaJogoUsuario(ApostaJogoUsuario aposta)
        {
            this.UserName = aposta.UserName;
            this.ApostaTime1 = aposta.ApostaTime1;
            this.ApostaTime2 = aposta.ApostaTime2;
        }
        public ApostaJogoUsuario(Domain.Entities.Boloes.JogoUsuario jogoUsuario)
        {
            this.ApostaTime1 = jogoUsuario.ApostaTime1 ?? 0;
            this.ApostaTime2 = jogoUsuario.ApostaTime2 ?? 0;
            this.UserName = jogoUsuario.UserName;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "";

            if (!string.IsNullOrEmpty(this.UserName))
                res += this.UserName;

            res += " - " + this.ApostaTime1 + " x " + this.ApostaTime2;

            return res;
        }

        #endregion
    }
}
