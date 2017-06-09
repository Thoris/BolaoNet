using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoMembroClassificacaoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoMembroClassificacao>, Domain.Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroClassificacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
