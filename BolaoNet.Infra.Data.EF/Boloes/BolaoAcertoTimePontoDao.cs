using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoAcertoTimePontoDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoAcertoTimePonto>, Domain.Interfaces.Repositories.Boloes.IBolaoAcertoTimePontoDao
    {
        
        #region Constructors/Destructors

        public BolaoAcertoTimePontoDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
