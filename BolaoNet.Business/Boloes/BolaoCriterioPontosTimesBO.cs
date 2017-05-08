using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoCriterioPontosTimesBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoCriterioPontosTimes>,
        Interfaces.Boloes.IBolaoCriterioPontosTimesBO
    {
        #region Constructors/Destructors

        public BolaoCriterioPontosTimesBO(string userName, Dao.Boloes.IBolaoCriterioPontosTimesDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoCriterioPontosTimes>)dao)
        {

        }

        #endregion
    }
}
