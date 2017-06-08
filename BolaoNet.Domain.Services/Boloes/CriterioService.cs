using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class CriterioService :
        Base.BaseGenericService<Entities.Boloes.Criterio>,
        Interfaces.Services.Boloes.ICriterioService
    {
        #region Constructors/Destructors

        public CriterioService(string userName, Interfaces.Repositories.Boloes.ICriterioDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Criterio>)dao)
        {

        }

        #endregion
    }
}
