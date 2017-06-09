using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class ApostasRestantesUserRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.ApostasRestantesUser>, Domain.Interfaces.Repositories.Boloes.IApostasRestantesUserDao
    {
        
        #region Constructors/Destructors

        public ApostasRestantesUserRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
