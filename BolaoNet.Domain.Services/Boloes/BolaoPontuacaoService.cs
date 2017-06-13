using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoPontuacaoService :
        Base.BaseGenericService<Entities.Boloes.BolaoPontuacao>,
        Interfaces.Services.Boloes.IBolaoPontuacaoService
    {
        #region Constructors/Destructors

        public BolaoPontuacaoService(string userName, Interfaces.Repositories.Boloes.IBolaoPontuacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoPontuacao>)dao, logging)
        {

        }

        #endregion
    }
}
