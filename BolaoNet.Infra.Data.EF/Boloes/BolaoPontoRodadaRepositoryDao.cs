using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoPontoRodadaRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoPontoRodada>, Domain.Interfaces.Repositories.Boloes.IBolaoPontoRodadaDao
    {
        
        #region Constructors/Destructors

        public BolaoPontoRodadaRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
