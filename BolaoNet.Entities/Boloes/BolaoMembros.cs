using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoMembros : Entities.Boloes.Pontuacao
    {
        #region Properties
        
        public int Posicao {get;set;}
        public int LastPosicao{get;set;}
        public string UserName{get;set;}
        public Entities.Boloes.Bolao Bolao{get;set;}
        public string FullName{get;set;}

        #endregion
    }
}
