using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoHistoricoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoHistorico>,
        Interfaces.Services.Campeonatos.ICampeonatoHistoricoService
    {
        #region Constructors/Destructors

        public CampeonatoHistoricoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoHistorico>)dao, logging)
        {

        }

        #endregion
    }
}
