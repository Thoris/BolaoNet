using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoPremioService :
        Base.BaseGenericService<Entities.Boloes.BolaoPremio>,
        Interfaces.Services.Boloes.IBolaoPremioService
    {
        #region Constructors/Destructors

        public BolaoPremioService(string userName, Interfaces.Repositories.Boloes.IBolaoPremioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoPremio>)dao, logging)
        {

        }

        #endregion
    }
}
