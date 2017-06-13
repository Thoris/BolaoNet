using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.DadosBasicos
{
    public class EstadioService :
        Base.BaseGenericService<Entities.DadosBasicos.Estadio>,
        Interfaces.Services.DadosBasicos.IEstadioService
    {
        #region Constructors/Destructors

        public EstadioService(string userName, Interfaces.Repositories.DadosBasicos.IEstadioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.DadosBasicos.Estadio>)dao, logging)
        {

        }

        #endregion
    }
}
