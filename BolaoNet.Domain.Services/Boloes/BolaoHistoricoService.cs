using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoHistoricoService :
        Base.BaseGenericService<Entities.Boloes.BolaoHistorico>,
        Interfaces.Services.Boloes.IBolaoHistoricoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoHistoricoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoHistoricoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoHistoricoService(string userName, Interfaces.Repositories.Boloes.IBolaoPremioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoHistorico>)dao, logging)
        {

        }

        #endregion

        #region IBolaoPremioService members

        #endregion
    }
}
