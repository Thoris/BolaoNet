using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class PontuacaoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.Pontuacao>, Domain.Interfaces.Repositories.Campeonatos.IPontuacaoDao
    {
        
        #region Constructors/Destructors

        public PontuacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
