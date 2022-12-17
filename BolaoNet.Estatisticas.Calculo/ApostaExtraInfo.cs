using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class ApostaExtraInfo
    {
        #region Properties

        public string NomeTimeValidado { get; set; }
        public int Posicao { get; set; }
        public int Pontuacao { get; set; }
        public List<ApostaExtraAposta> Apostas { get; set; }
        public List<ApostaExtraPossibilidade> Possibilidades { get; set; }
        
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
