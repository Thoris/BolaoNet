using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoGrupoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.CampeonatoGrupo>, Dao.Campeonatos.ICampeonatoGrupoDao
    {
        
        #region Constructors/Destructors

        public CampeonatoGrupoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
