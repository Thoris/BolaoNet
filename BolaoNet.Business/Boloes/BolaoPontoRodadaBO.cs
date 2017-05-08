using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoPontoRodadaBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoPontoRodada>,
        Interfaces.Boloes.IBolaoPontoRodadaBO
    {
        #region Constructors/Destructors

        public BolaoPontoRodadaBO(string userName, Dao.Boloes.IBolaoPontoRodadaDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoPontoRodada>)dao)
        {

        }

        #endregion
    }
}
