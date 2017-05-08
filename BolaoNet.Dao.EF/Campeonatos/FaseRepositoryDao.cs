using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class FaseRepositoryDao :
        Base.BaseRepositoryDao<Entities.Campeonatos.Fase>, Dao.Campeonatos.IFaseDao
    {
        
        #region Constructors/Destructors

        public FaseRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
