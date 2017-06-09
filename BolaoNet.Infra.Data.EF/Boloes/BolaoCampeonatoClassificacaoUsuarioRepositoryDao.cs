using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>, Domain.Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao
    {
        
        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
