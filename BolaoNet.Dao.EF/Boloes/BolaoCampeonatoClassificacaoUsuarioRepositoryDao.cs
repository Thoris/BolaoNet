using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>, Dao.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao
    {
        
        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
