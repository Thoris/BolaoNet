using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class ApostaExtraUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.ApostaExtraUsuario>, Dao.Boloes.IApostaExtraUsuarioDao
    {
        
        #region Constructors/Destructors

        public ApostaExtraUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
