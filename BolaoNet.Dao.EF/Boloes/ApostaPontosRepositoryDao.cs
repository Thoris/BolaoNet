using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class ApostaPontosRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Boloes.ApostaPontos>
    {
        
        #region Constructors/Destructors

        public ApostaPontosRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
