using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoPontoRodadaUsuarioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoPontoRodadaUsuario>,
        Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO
    {
        #region Constructors/Destructors

        public BolaoPontoRodadaUsuarioBO(string userName, Dao.Boloes.IBolaoPontoRodadaUsuarioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoPontoRodadaUsuario>)dao)
        {

        }

        #endregion
    }
}
