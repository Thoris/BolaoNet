using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoCriterioPontosTimesRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoCriterioPontosTimes>, Domain.Interfaces.Repositories.Boloes.IBolaoCriterioPontosTimesDao
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosTimesRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
