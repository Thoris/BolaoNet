using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoCriterioPontosBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoCriterioPontos>,
        Interfaces.Boloes.IBolaoCriterioPontosBO
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosBO(string userName, Dao.Boloes.IBolaoCriterioPontosDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoCriterioPontos>)dao)
        {

        }

        #endregion
    }
}
