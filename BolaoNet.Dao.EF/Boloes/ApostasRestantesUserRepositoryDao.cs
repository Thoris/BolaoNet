using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class ApostasRestantesUserRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Boloes.ApostasRestantesUser>, Dao.Boloes.IApostasRestantesUserDao
    {
        
        #region Constructors/Destructors

        public ApostasRestantesUserRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
