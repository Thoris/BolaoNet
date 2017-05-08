using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.Campeonato>,
        Interfaces.Campeonatos.ICampeonatoBO
    {

        #region Constructors/Destructors

        public CampeonatoBO(string userName, Dao.Campeonatos.ICampeonatoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Campeonato>)dao)
        {

        }

        #endregion
    }
}
