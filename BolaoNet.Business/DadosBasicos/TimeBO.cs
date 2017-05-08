using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.DadosBasicos
{
    public class TimeBO :
        Base.BaseGenericBusinessBO<Entities.DadosBasicos.Time>,
        Interfaces.DadosBasicos.ITimeBO
    {
        
        #region Constructors/Destructors

        public TimeBO(string userName, Dao.DadosBasicos.ITimeDao dao)
            : base (userName, (Dao.Base.IGenericDao<Entities.DadosBasicos.Time>)dao)
        {

        }

        #endregion
    }
}
