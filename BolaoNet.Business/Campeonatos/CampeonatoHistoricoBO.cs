using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoHistoricoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoHistorico>,
        Interfaces.Campeonatos.ICampeonatoHistoricoBO
    {
        #region Constructors/Destructors

        public CampeonatoHistoricoBO(string userName, Dao.Campeonatos.ICampeonatoHistoricoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoHistorico>)dao)
        {

        }

        #endregion
    }
}
