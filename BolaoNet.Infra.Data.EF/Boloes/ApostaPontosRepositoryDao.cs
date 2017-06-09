using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class ApostaPontosRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.ApostaPontos>,
        Domain.Interfaces.Repositories.Boloes.IApostaPontosDao
    {
        
        #region Constructors/Destructors

        public ApostaPontosRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
