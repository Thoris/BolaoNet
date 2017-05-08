using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class PontuacaoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.Pontuacao>,
        Interfaces.Boloes.IPontuacaoBO
    {
        #region Constructors/Destructors

        public PontuacaoBO(string userName, Dao.Boloes.IPontuacaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.Pontuacao>)dao)
        {

        }

        #endregion
    }
}
