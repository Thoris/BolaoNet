using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes.Reports
{
    public class UserClassificacao : Base.AuditModel
    {
        #region Properties
        
        public int Posicao {get;set;}
        public int Pontos{get;set;}
        public int Rodada{get;set;}
        public string UserName{get;set;}

        #endregion
    }
}
