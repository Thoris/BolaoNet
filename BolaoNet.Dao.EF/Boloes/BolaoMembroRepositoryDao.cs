using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoMembroRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoMembro>, Dao.Boloes.IBolaoMembroDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
