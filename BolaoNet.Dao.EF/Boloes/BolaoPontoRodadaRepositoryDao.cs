using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoPontoRodadaRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoPontoRodada>, Dao.Boloes.IBolaoPontoRodadaDao
    {
        
        #region Constructors/Destructors

        public BolaoPontoRodadaRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
