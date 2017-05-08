using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoRegraRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoRegra>, Dao.Boloes.IBolaoRegraDao
    {
        
        #region Constructors/Destructors

        public BolaoRegraRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
