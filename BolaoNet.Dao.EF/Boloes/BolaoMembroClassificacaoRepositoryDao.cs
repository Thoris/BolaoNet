using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoMembroClassificacaoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoMembroClassificacao>, Dao.Boloes.IBolaoMembroClassificacaoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroClassificacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
