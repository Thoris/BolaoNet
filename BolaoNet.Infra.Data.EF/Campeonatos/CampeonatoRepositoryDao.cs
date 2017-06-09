using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.Campeonato>, Domain.Interfaces.Repositories.Campeonatos.ICampeonatoDao
    {
        #region Constructors/Destructors

        public CampeonatoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
