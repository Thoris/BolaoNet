using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class PontuacaoRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.Pontuacao>, Dao.Boloes.IPontuacaoDao
    {
        
        #region Constructors/Destructors

        public PontuacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
