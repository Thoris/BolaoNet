using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoRequestStatusRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoRequestStatus>, Dao.Boloes.IBolaoRequestStatusDao
    {
        
        #region Constructors/Destructors

        public BolaoRequestStatusRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
