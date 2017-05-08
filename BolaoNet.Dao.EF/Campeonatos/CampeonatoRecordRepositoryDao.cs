using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoRecordRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.CampeonatoRecord>, Dao.Campeonatos.ICampeonatoRecordDao
    {
        
        #region Constructors/Destructors

        public CampeonatoRecordRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
