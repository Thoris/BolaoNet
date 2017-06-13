using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoGrupoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoGrupo>,
        Interfaces.Services.Campeonatos.ICampeonatoGrupoService
    {
        #region Constructors/Destructors

        public CampeonatoGrupoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoGrupo>)dao, logging)
        {

        }

        #endregion
    }
}
