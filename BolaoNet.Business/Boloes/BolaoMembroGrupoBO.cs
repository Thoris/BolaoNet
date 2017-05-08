using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoMembroGrupoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoMembroGrupo>,
        Interfaces.Boloes.IBolaoMembroGrupoBO
    {
        #region Constructors/Destructors

        public BolaoMembroGrupoBO(string userName, Dao.Boloes.IBolaoMembroGrupoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoMembroGrupo>)dao)
        {

        }

        #endregion
    }
}
