using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.DadosBasicos
{
    public class CriterioFixoService :
        Base.BaseGenericService<Entities.DadosBasicos.CriterioFixo>,
        Interfaces.Services.DadosBasicos.ICriterioFixoService
    {
        #region Constructors/Destructors

        public CriterioFixoService(string userName, Interfaces.Repositories.DadosBasicos.ICriterioFixoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.DadosBasicos.CriterioFixo>)dao, logging)            
        {

        }

        #endregion
    }
}
