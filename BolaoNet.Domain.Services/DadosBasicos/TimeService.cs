using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.DadosBasicos
{
    public class TimeService :
        Base.BaseGenericService<Entities.DadosBasicos.Time>,
        Interfaces.Services.DadosBasicos.ITimeService
    {
        
        #region Constructors/Destructors

        public TimeService(string userName, Interfaces.Repositories.DadosBasicos.ITimeDao dao)
            : base (userName, (Interfaces.Repositories.Base.IGenericDao<Entities.DadosBasicos.Time>)dao)
        {

        }

        #endregion
    }
}
