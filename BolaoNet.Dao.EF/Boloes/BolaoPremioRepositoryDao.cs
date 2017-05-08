using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoPremioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoPremio>, Dao.Boloes.IBolaoPremioDao
    {
        
        #region Constructors/Destructors

        public BolaoPremioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
