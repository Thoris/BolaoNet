using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class ApostaExtraBO : 
        Base.BaseGenericBusinessBO<Entities.Boloes.ApostaExtra>,
        Interfaces.Boloes.IApostaExtraBO
    {      
        
        #region Constructors/Destructors

        public ApostaExtraBO(string userName, Dao.Boloes.IApostaExtraDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.ApostaExtra>)dao)
        {

        }

        #endregion
    }
}
