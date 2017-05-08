using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoFaseBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoFase>,
        Interfaces.Campeonatos.ICampeonatoFaseBO
    {
        #region Constructors/Destructors

        public CampeonatoFaseBO(string userName, Dao.Campeonatos.ICampeonatoFaseDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoFase>)dao)
        {

        }

        #endregion
    }
}
