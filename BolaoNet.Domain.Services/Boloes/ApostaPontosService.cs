using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class ApostaPontosService :
        Base.BaseGenericService<Entities.Boloes.ApostaPontos>,
        Interfaces.Services.Boloes.IApostaPontosService
    {
        #region Constructors/Destructors

        public ApostaPontosService(string userName, Interfaces.Repositories.Boloes.IApostaPontosDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.ApostaPontos>)dao, logging)
        {

        }

        #endregion
    }
}
