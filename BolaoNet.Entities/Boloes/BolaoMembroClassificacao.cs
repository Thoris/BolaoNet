using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoMembroClassificacao : Entities.Boloes.Pontuacao
    {
        #region Properties

        public int ? Posicao {get;set;}
        public int ? LastPosicao{get;set;}

        #endregion
    }
}
