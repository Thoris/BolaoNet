using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoTimeRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.CampeonatoTime>, Dao.Campeonatos.ICampeonatoTimeDao
    {
        
        #region Constructors/Destructors

        public CampeonatoTimeRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
