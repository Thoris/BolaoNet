using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class PontuacaoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.Pontuacao>, Domain.Interfaces.Repositories.Boloes.IPontuacaoDao
    {
        
        #region Constructors/Destructors

        public PontuacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
