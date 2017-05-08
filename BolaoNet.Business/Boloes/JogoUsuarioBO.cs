using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class JogoUsuarioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.JogoUsuario>,
        Interfaces.Boloes.IJogoUsuarioBO
    {
        #region Constructors/Destructors

        public JogoUsuarioBO(string userName, Dao.Boloes.IJogoUsuarioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.JogoUsuario>)dao)
        {

        }

        #endregion
    }
}
