using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoGrupoTimeService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoGrupoTime>,
        Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService
    {
        #region Constructors/Destructors

        public CampeonatoGrupoTimeService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoGrupoTimeDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoGrupoTime>)dao, logging)
        {

        }

        #endregion
    }
}
