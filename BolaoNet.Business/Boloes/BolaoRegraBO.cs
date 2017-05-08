using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoRegraBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoRegra>,
        Interfaces.Boloes.IBolaoRegraBO
    {
        #region Constructors/Destructors

        public BolaoRegraBO(string userName, Dao.Boloes.IBolaoRegraDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoRegra>)dao)
        {

        }

        #endregion
    }
}
