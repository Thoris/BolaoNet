using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Campeonatos.Campeonato>, Dao.Campeonatos.ICampeonatoDao
    {
        #region Constructors/Destructors

        public CampeonatoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
