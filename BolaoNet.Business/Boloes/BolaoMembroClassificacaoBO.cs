using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoMembroClassificacaoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoMembroClassificacao>,
        Interfaces.Boloes.IBolaoMembroClassificacaoBO
    {
        #region Constructors/Destructors

        public BolaoMembroClassificacaoBO(string userName, Dao.Boloes.IBolaoMembroClassificacaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoMembroClassificacao>)dao)
        {

        }

        #endregion
    }
}
