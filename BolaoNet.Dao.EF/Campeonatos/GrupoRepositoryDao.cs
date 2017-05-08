using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class GrupoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Campeonatos.Grupo>, Dao.Campeonatos.IGrupoDao
    {
        
        #region Constructors/Destructors

        public GrupoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
