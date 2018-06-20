using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class JogoPossibilidade
    {
        #region Properties

        public short GolsTime1 { get; set; }
        public short GolsTime2 { get; set; }
        public int TotalApostas { get; set; }
        public List<ApostaPontos> Pontuacao {get; set;}

        #endregion

        #region Constructors/Destructors

        public JogoPossibilidade()
        {

        }
        public JogoPossibilidade(ApostaJogoUsuario aposta)
        {
            this.GolsTime1 = (short)aposta.ApostaTime1;
            this.GolsTime2 = (short)aposta.ApostaTime2;
            this.TotalApostas = 1;
        }
        public JogoPossibilidade(short gols1, short gols2)
        {
            this.GolsTime1 = gols1;
            this.GolsTime2 = gols2;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = GolsTime1 + " x " + GolsTime2 + " [" + TotalApostas + "]";

            if (this.Pontuacao != null)
                res += " - " + this.Pontuacao.Count;

            return res;
        }

        #endregion
    }
}
