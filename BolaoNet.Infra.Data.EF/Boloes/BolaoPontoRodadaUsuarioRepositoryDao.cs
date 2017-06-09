using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoPontoRodadaUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoPontoRodadaUsuario>, Domain.Interfaces.Repositories.Boloes.IBolaoPontoRodadaUsuarioDao
    {
        
        #region Constructors/Destructors

        public BolaoPontoRodadaUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
