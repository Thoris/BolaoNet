using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class CriterioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.Criterio>, Dao.Boloes.ICriterioDao
    {
        
        #region Constructors/Destructors

        public CriterioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
