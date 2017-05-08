using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoRequestBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoRequest>,
        Interfaces.Boloes.IBolaoRequestBO
    {
        #region Constructors/Destructors

        public BolaoRequestBO(string userName, Dao.Boloes.IBolaoRequestDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoRequest>)dao)
        {

        }

        #endregion
    }
}
