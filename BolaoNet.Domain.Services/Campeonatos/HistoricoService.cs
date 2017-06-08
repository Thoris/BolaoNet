using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class HistoricoService :
        Base.BaseGenericService<Entities.Campeonatos.Historico>,
        Interfaces.Services.Campeonatos.IHistoricoService
    {
        #region Constructors/Destructors

        public HistoricoService(string userName, Interfaces.Repositories.Campeonatos.IHistoricoDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.Historico>)dao)
        {

        }

        #endregion
    }
}
