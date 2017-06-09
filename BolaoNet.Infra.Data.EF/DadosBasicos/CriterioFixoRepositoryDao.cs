using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.DadosBasicos
{
    public class CriterioFixoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.DadosBasicos.CriterioFixo>, Domain.Interfaces.Repositories.DadosBasicos.ICriterioFixoDao
    {
        
        #region Constructors/Destructors

        public CriterioFixoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
