using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoPontuacaoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoPontuacao>, Dao.Boloes.IBolaoPontuacaoDao
    {
        
        #region Constructors/Destructors

        public BolaoPontuacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
