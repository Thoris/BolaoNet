using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class PontuacaoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.Pontuacao>, Dao.Campeonatos.IPontuacaoDao
    {
        
        #region Constructors/Destructors

        public PontuacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
