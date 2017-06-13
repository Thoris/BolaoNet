using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.DadosBasicos
{
    public class PagamentoTipoService :
        Base.BaseGenericService<Entities.DadosBasicos.PagamentoTipo>,
        Interfaces.Services.DadosBasicos.IPagamentoTipoService
    {
        #region Constructors/Destructors

        public PagamentoTipoService(string userName, Interfaces.Repositories.DadosBasicos.IPagamentoTipoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.DadosBasicos.PagamentoTipo>)dao, logging)
        {

        }

        #endregion
    }
}
