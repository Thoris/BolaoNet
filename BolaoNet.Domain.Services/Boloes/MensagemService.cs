using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class MensagemService :
        Base.BaseGenericService<Entities.Boloes.Mensagem>,
        Interfaces.Services.Boloes.IMensagemService
    {
        #region Constructors/Destructors

        public MensagemService(string userName, Interfaces.Repositories.Boloes.IMensagemDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Mensagem>)dao)
        {

        }

        #endregion
    }
}
