using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoTimeBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoTime>,
        Interfaces.Campeonatos.ICampeonatoTimeBO
    {
        #region Constructors/Destructors

        public CampeonatoTimeBO(string userName, Dao.Campeonatos.ICampeonatoTimeDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoTime>)dao)
        {

        }

        #endregion
    }
}
