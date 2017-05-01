using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes.Reports
{
    public class UserClassificacaoRodada 
    {
        #region Properties
        public int Rodada {get;set;}
        public IList<Entities.Boloes.Reports.UserClassificacao> Membros {get;set;}

        #endregion
    }
}
