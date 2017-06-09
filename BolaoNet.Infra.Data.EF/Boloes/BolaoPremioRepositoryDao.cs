using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoPremioRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoPremio>, Domain.Interfaces.Repositories.Boloes.IBolaoPremioDao
    {
        
        #region Constructors/Destructors

        public BolaoPremioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
