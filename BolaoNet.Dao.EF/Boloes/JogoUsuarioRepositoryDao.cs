using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class JogoUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.JogoUsuario>, Dao.Boloes.IJogoUsuarioDao
    {
        
        #region Constructors/Destructors

        public JogoUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
