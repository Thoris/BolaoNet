using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoRequestRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoRequest>, Domain.Interfaces.Repositories.Boloes.IBolaoRequestDao
    {
        
        #region Constructors/Destructors

        public BolaoRequestRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
