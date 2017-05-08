using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class ApostaExtraUsuarioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.ApostaExtraUsuario>,
        Interfaces.Boloes.IApostaExtraUsuarioBO
    {
        #region Constructors/Destructors

        public ApostaExtraUsuarioBO(string userName, Dao.Boloes.IApostaExtraUsuarioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.ApostaExtraUsuario>)dao)
        {

        }

        #endregion
    }
}
