using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class PagamentoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.Pagamento>, Domain.Interfaces.Repositories.Boloes.IPagamentoDao
    {
        
        #region Constructors/Destructors

        public PagamentoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
