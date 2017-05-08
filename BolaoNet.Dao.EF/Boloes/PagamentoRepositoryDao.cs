using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class PagamentoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.Pagamento>, Dao.Boloes.IPagamentoDao
    {
        
        #region Constructors/Destructors

        public PagamentoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
