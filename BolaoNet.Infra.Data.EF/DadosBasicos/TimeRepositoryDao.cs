using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.DadosBasicos
{
    public class TimeRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.DadosBasicos.Time>, Domain.Interfaces.Repositories.DadosBasicos.ITimeDao
    {
        
        #region Constructors/Destructors

        public TimeRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
