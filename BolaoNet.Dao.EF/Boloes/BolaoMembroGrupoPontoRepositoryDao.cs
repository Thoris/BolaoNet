using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoMembroGrupoPontoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoMembroGrupoPonto>, Dao.Boloes.IBolaoMembroGrupoPontoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroGrupoPontoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
