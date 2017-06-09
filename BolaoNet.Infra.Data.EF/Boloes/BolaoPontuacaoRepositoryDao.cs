using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoPontuacaoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoPontuacao>, Domain.Interfaces.Repositories.Boloes.IBolaoPontuacaoDao
    {
        
        #region Constructors/Destructors

        public BolaoPontuacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
