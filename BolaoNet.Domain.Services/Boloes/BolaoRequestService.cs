using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoRequestService :
        Base.BaseGenericService<Entities.Boloes.BolaoRequest>,
        Interfaces.Services.Boloes.IBolaoRequestService
    {
        #region Constructors/Destructors

        public BolaoRequestService(string userName, Interfaces.Repositories.Boloes.IBolaoRequestDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoRequest>)dao)
        {

        }

        #endregion
    }
}
