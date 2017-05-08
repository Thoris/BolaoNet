using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoMembroGrupoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoMembroGrupo>, Dao.Boloes.IBolaoMembroGrupoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroGrupoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
