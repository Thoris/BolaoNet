using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class ApostaExtraInfo
    {
        #region Properties

        public int Posicao { get; set; }
        public int Pontuacao { get; set; }
        public IList<ApostaExtraAposta> Apostas { get; set; }
        public IList<ApostaExtraPossibilidade> Possibilidades { get; set; }
        

        #endregion

        #region Constructors/Destructors

        public ApostaExtraInfo()
        {
            this.Apostas = new List<ApostaExtraAposta>();
        }
        public ApostaExtraInfo(Domain.Entities.Boloes.ApostaExtra extra)
        {
            this.Apostas = new List<ApostaExtraAposta>();
            this.Posicao = extra.Posicao;
            this.Pontuacao = (int)extra.TotalPontos;

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "Posição: " + Posicao + " : " + Pontuacao + " . Apostas: " + this.Apostas.Count;

            return res;
        }

        #endregion
    }
}
