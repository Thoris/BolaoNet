using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoCriterioPontosRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoCriterioPontos>, Dao.Boloes.IBolaoCriterioPontosDao
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
