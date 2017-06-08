using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoRequestStatusService :
        Base.BaseGenericService<Entities.Boloes.BolaoRequestStatus>,
        Interfaces.Services.Boloes.IBolaoRequestStatusService
    {
        #region Constructors/Destructors

        public BolaoRequestStatusService(string userName, Interfaces.Repositories.Boloes.IBolaoRequestStatusDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoRequestStatus>)dao)
        {

        }

        #endregion
    }
}
