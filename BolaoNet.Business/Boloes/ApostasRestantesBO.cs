using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class ApostasRestantesUserBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.ApostasRestantesUser>,
        Interfaces.Boloes.IApostasRestantesBO
    {
        #region Constructors/Destructors

        public ApostasRestantesUserBO(string userName, Dao.Boloes.IApostasRestantesUserDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.ApostasRestantesUser>)dao)
        {

        }

        #endregion
    }
}
