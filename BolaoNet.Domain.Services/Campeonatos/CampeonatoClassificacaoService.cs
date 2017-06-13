using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoClassificacaoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoClassificacao>,
        Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService
    {
        #region Constructors/Destructors

        public CampeonatoClassificacaoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoClassificacao>)dao, logging)
        {

        }

        #endregion
    }
}
