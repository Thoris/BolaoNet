using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoMembroGrupoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoMembroGrupo>, Domain.Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroGrupoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
