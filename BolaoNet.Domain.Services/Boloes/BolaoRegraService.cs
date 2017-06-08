using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoRegraService :
        Base.BaseGenericService<Entities.Boloes.BolaoRegra>,
        Interfaces.Services.Boloes.IBolaoRegraService
    {
        #region Constructors/Destructors

        public BolaoRegraService(string userName, Interfaces.Repositories.Boloes.IBolaoRegraDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoRegra>)dao)
        {

        }

        #endregion
    }
}
