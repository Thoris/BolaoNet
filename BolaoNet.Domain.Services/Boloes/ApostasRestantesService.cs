using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class ApostasRestantesUserBO :
        Base.BaseGenericService<Entities.Boloes.ApostasRestantesUser>,
        Interfaces.Services.Boloes.IApostasRestantesService
    {
        #region Constructors/Destructors

        public ApostasRestantesUserBO(string userName, Interfaces.Repositories.Boloes.IApostasRestantesUserDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.ApostasRestantesUser>)dao, logging)
        {

        }

        #endregion
    }
}
