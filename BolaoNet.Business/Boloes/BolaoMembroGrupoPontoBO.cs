using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoMembroGrupoPontoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoMembroGrupoPonto>,
        Interfaces.Boloes.IBolaoMembroGrupoPontoBO
    {
        #region Constructors/Destructors

        public BolaoMembroGrupoPontoBO(string userName, Dao.Boloes.IBolaoMembroGrupoPontoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoMembroGrupoPonto>)dao)
        {

        }

        #endregion
    }
}
