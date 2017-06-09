using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoFaseRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoFase>, Domain.Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao
    {
        
        #region Constructors/Destructors

        public CampeonatoFaseRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
