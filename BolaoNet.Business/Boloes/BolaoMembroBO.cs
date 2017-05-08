using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoMembroBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoMembro>,
        Interfaces.Boloes.IBolaoMembroBO
    {
        #region Constructors/Destructors

        public BolaoMembroBO(string userName, Dao.Boloes.IBolaoMembroDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoMembro>)dao)
        {

        }

        #endregion
    }
}
