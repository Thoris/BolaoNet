using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoHistoricoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.CampeonatoHistorico>, Dao.Campeonatos.ICampeonatoHistoricoDao
    {
        
        #region Constructors/Destructors

        public CampeonatoHistoricoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
