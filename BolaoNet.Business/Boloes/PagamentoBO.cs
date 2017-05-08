using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class PagamentoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.Pagamento>,
        Interfaces.Boloes.IPagamentoBO
    {
        #region Constructors/Destructors

        public PagamentoBO(string userName, Dao.Boloes.IPagamentoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.Pagamento>)dao)
        {

        }

        #endregion
    }
}
