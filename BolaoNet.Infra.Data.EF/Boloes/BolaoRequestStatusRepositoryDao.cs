using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoRequestStatusRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoRequestStatus>, 
        Domain.Interfaces.Repositories.Boloes.IBolaoRequestStatusDao
    {
        
        #region Constructors/Destructors

        public BolaoRequestStatusRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
