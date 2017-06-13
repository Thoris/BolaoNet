using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class PontuacaoService :
        Base.BaseGenericService<Entities.Boloes.Pontuacao>,
        Interfaces.Services.Boloes.IPontuacaoService
    {
        #region Constructors/Destructors

        public PontuacaoService(string userName, Interfaces.Repositories.Boloes.IPontuacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Pontuacao>)dao, logging)
        {

        }

        #endregion
    }
}
