using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class HistoricoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.Historico>,
        Interfaces.Campeonatos.IHistoricoBO
    {
        #region Constructors/Destructors

        public HistoricoBO(string userName, Dao.Campeonatos.IHistoricoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Historico>)dao)
        {

        }

        #endregion
    }
}
