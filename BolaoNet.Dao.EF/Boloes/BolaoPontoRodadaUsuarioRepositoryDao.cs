using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoPontoRodadaUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoPontoRodadaUsuario>, Dao.Boloes.IBolaoPontoRodadaUsuarioDao
    {
        
        #region Constructors/Destructors

        public BolaoPontoRodadaUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
