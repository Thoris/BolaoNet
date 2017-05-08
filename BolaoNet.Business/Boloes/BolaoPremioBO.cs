using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoPremioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoPremio>,
        Interfaces.Boloes.IBolaoPremioBO
    {
        #region Constructors/Destructors

        public BolaoPremioBO(string userName, Dao.Boloes.IBolaoPremioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoPremio>)dao)
        {

        }

        #endregion
    }
}
