using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class ApostaPontosBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.ApostaPontos>,
        Interfaces.Boloes.IApostaPontosBO
    {
        #region Constructors/Destructors

        public ApostaPontosBO(string userName, Dao.Boloes.IApostaPontosDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.ApostaPontos>)dao)
        {

        }

        #endregion
    }
}
