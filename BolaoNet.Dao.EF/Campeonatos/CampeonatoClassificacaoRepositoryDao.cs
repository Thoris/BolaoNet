using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class CampeonatoClassificacaoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.CampeonatoClassificacao>, Dao.Campeonatos.ICampeonatoClassificacaoDao
    {

        
        #region Constructors/Destructors

        public CampeonatoClassificacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
