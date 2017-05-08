using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoRecordBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoRecord>,
        Interfaces.Campeonatos.ICampeonatoRecordBO
    {
        #region Constructors/Destructors

        public CampeonatoRecordBO(string userName, Dao.Campeonatos.ICampeonatoRecordDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoRecord>)dao)
        {

        }

        #endregion
    }
}
