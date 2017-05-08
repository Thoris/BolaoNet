using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoRequestRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoRequest>, Dao.Boloes.IBolaoRequestDao
    {
        
        #region Constructors/Destructors

        public BolaoRequestRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
