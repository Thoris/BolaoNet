using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class PagamentoService :
        Base.BaseGenericService<Entities.Boloes.Pagamento>,
        Interfaces.Services.Boloes.IPagamentoService
    {
        #region Constructors/Destructors

        public PagamentoService(string userName, Interfaces.Repositories.Boloes.IPagamentoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Pagamento>)dao, logging)
        {

        }

        #endregion
    }
}
