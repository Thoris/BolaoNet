using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class JogoInfo
    {
        #region Properties

        public int JogoId { get; set; }
        public string NomeTime1 { get; set; }
        public string NomeTime2 { get; set; }
        public int GolsTime1 { get; set; }
        public int GolsTime2 { get; set; }
        public List<ApostaJogoUsuario> Apostas { get; set; }
        public List<JogoPossibilidade> Possibilidades { get; set; }
        public bool IsValid { get; set; }

        #endregion

        #region Constructors/Destructors

        public JogoInfo()
        {
            this.Apostas = new List<ApostaJogoUsuario>();
        }
        public JogoInfo(Domain.Entities.Campeonatos.Jogo jogo)
        {
            this.JogoId = jogo.JogoId;
            this.NomeTime1 = jogo.NomeTime1;
            this.NomeTime2 = jogo.NomeTime2;
            this.GolsTime1 = jogo.GolsTime1;
            this.GolsTime2 = jogo.GolsTime2;
            this.IsValid = jogo.IsValido;
            this.Apostas = new List<ApostaJogoUsuario>();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = this.JogoId + " - ";
            res += "[";

            if (!string.IsNullOrEmpty(this.NomeTime1))
                res += this.NomeTime1 ;

            res += "] " + this.GolsTime1 + " x " + this.GolsTime2 + " [";

            if (!string.IsNullOrEmpty(this.NomeTime2))
                res += this.NomeTime2;

            res += "] . Apostas: ";

            if (this.Apostas != null)
                res += this.Apostas.Count;
            else
                res += "null";

            res += " . Possibilidades: ";

            if (this.Possibilidades != null)
                res += this.Possibilidades.Count;
            else
                res += "null";


            return res;
        }

        #endregion
    }
}
