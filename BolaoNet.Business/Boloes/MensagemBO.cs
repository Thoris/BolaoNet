using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class MensagemBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.Mensagem>,
        Interfaces.Boloes.IMensagemBO
    {
        #region Constructors/Destructors

        public MensagemBO(string userName, Dao.Boloes.IMensagemDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.Mensagem>)dao)
        {

        }

        #endregion
    }
}
