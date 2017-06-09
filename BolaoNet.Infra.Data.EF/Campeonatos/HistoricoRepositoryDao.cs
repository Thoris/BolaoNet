using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class HistoricoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.Historico>, Domain.Interfaces.Repositories.Campeonatos.IHistoricoDao
    {
        
        #region Constructors/Destructors

        public HistoricoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
