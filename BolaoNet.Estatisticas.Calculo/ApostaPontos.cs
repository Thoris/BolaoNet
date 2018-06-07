using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class ApostaPontos
    {
        #region Properties

        public string UserName { get; set; }
        public int Pontos { get; set; }
        
        #endregion

        #region Constructors/Destructors

        public ApostaPontos()
        {

        }
        public ApostaPontos(string userName)
        {
            this.UserName = userName;
        }

        #endregion

        #region Methods

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
