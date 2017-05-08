using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class CriterioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.Criterio>,
        Interfaces.Boloes.ICriterioBO
    {
        #region Constructors/Destructors

        public CriterioBO(string userName, Dao.Boloes.ICriterioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.Criterio>)dao)
        {

        }

        #endregion
    }
}
