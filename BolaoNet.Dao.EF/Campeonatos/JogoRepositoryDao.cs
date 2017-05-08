using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class JogoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.Jogo>, Dao.Campeonatos.IJogoDao
    {
        
        #region Constructors/Destructors

        public JogoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
