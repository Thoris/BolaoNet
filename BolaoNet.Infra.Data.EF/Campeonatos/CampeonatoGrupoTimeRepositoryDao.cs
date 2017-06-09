using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoGrupoTimeRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoGrupoTime>, Domain.Interfaces.Repositories.Campeonatos.ICampeonatoGrupoTimeDao
    {

        #region Constructors/Destructors

        public CampeonatoGrupoTimeRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
