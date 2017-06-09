using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoRecordRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoRecord>, Domain.Interfaces.Repositories.Campeonatos.ICampeonatoRecordDao
    {
        
        #region Constructors/Destructors

        public CampeonatoRecordRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
