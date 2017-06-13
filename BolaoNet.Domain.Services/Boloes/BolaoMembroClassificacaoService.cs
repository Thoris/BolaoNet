using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoMembroClassificacaoService :
        Base.BaseGenericService<Entities.Boloes.BolaoMembroClassificacao>,
        Interfaces.Services.Boloes.IBolaoMembroClassificacaoService
    {
        #region Constructors/Destructors

        public BolaoMembroClassificacaoService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembroClassificacao>)dao, logging)
        {

        }

        #endregion
    }
}
