using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.Bolao>,
        Interfaces.Boloes.IBolaoBO
    {
        #region Constructors/Destructors

        public BolaoBO(string userName, Dao.Boloes.IBolaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.Bolao>)dao)
        {

        }

        #endregion
    }
}
