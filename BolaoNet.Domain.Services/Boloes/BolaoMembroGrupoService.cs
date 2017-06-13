using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoMembroGrupoService :
        Base.BaseGenericService<Entities.Boloes.BolaoMembroGrupo>,
        Interfaces.Services.Boloes.IBolaoMembroGrupoService
    {
        #region Constructors/Destructors

        public BolaoMembroGrupoService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembroGrupo>)dao, logging)
        {

        }

        #endregion
    }
}
