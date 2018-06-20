using BolaoNet.Domain.Entities.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class MembroClassificacao
    {
        #region Properties

        public string UserName { get; set; }
        public int? Posicao { get; set; }
        public int? Pontuacao { get; set; }

        #endregion

        #region Constructors/Destructors

        public MembroClassificacao()
        {

        }
        public MembroClassificacao(BolaoMembroClassificacao entity)
        {
            this.UserName = entity.UserName;
            this.Posicao = entity.Posicao;
            this.Pontuacao = entity.TotalPontos;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = "";

            if (!string.IsNullOrEmpty(this.UserName))
                res += "UserName: " + this.UserName;

            if (Posicao != null)
                res += " - Posição: " + this.Posicao;

            if (Pontuacao != null)
                res += " = Pontos: " + this.Pontuacao;

            return res;
        }

        #endregion
    }
}
