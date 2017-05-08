using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoCriterioPontosTimesRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoCriterioPontosTimes>, Dao.Boloes.IBolaoCriterioPontosTimesDao
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosTimesRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
