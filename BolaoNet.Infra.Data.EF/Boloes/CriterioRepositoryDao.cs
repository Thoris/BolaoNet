using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class CriterioRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.Criterio>, Domain.Interfaces.Repositories.Boloes.ICriterioDao
    {
        
        #region Constructors/Destructors

        public CriterioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
