using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class ApostaPontos
    {
        #region Properties

        public string UserName { get; set; }
        public int Pontos { get; set; }
        public int Gols1 { get; set; }
        public int Gols2 { get; set; }
        public int Posicao { get; set; }
        
        #endregion

        #region Constructors/Destructors

        public ApostaPontos()
        {

        }
        public ApostaPontos(string userName, int gols1, int gols2)
        {
            this.UserName = userName;
            this.Gols1 = gols1;
            this.Gols2 = gols2;
        }

        #endregion

        #region Methods

        public ApostaPontos Clone()
        {
            ApostaPontos entry = new ApostaPontos();
            entry.UserName = this.UserName;
            entry.Pontos = this.Pontos;
            entry.Gols1 = this.Gols1;
            entry.Gols2 = this.Gols2;
            entry.Posicao = this.Posicao;
            return entry;
        }
        public override string ToString()
        {
            string res = "[";

            if (!string.IsNullOrEmpty(this.UserName))
                res += this.UserName;

            res += "] - Pontos: " + this.Pontos;
            
            return res;
        }

        #endregion

    }
}
