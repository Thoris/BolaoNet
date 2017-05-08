using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO
    {
        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioBO(string userName, Dao.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>)dao)
        {

        }

        #endregion
    }
}
