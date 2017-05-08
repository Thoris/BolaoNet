using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class HistoricoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.Historico>, Dao.Campeonatos.IHistoricoDao
    {
        
        #region Constructors/Destructors

        public HistoricoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
