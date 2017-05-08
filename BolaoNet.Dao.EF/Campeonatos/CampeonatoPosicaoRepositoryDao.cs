using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoPosicaoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.CampeonatoPosicao>, Dao.Campeonatos.ICampeonatoPosicaoDao
    {
        
        #region Constructors/Destructors

        public CampeonatoPosicaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
