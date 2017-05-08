using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoPontuacaoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoPontuacao>,
        Interfaces.Boloes.IBolaoPontuacaoBO
    {
        #region Constructors/Destructors

        public BolaoPontuacaoBO(string userName, Dao.Boloes.IBolaoPontuacaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoPontuacao>)dao)
        {

        }

        #endregion
    }
}
