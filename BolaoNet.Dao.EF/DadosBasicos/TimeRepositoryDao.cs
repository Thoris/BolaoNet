using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.DadosBasicos
{
    public class TimeRepositoryDao : 
        Base.BaseRepositoryDao<Entities.DadosBasicos.Time>, Dao.DadosBasicos.ITimeDao
    {
        
        #region Constructors/Destructors

        public TimeRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
