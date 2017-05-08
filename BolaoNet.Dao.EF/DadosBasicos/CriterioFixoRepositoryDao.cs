using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.DadosBasicos
{
    public class CriterioFixoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.DadosBasicos.CriterioFixo>, Dao.DadosBasicos.ICriterioFixoDao
    {
        
        #region Constructors/Destructors

        public CriterioFixoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
