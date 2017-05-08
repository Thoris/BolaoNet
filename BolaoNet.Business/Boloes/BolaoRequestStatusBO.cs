using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoRequestStatusBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoRequestStatus>,
        Interfaces.Boloes.IBolaoRequestStatusBO
    {
        #region Constructors/Destructors

        public BolaoRequestStatusBO(string userName, Dao.Boloes.IBolaoRequestStatusDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoRequestStatus>)dao)
        {

        }

        #endregion
    }
}
