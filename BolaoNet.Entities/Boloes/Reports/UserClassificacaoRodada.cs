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

        public int Rodada { get; set; }
        //public IList<Entities.Boloes.Reports.UserClassificacao> Membros { get; set; }
        public virtual ICollection<Boloes.Reports.UserClassificacao> Membros { get; set; }

        #endregion

        #region Constructors/Destructors

        public UserClassificacaoRodada()
        {
            this.Membros = new List<Boloes.Reports.UserClassificacao>();
        }

        #endregion
    }
}
