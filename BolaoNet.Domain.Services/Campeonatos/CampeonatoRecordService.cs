using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoRecordService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoRecord>,
        Interfaces.Services.Campeonatos.ICampeonatoRecordService
    {
        #region Constructors/Destructors

        public CampeonatoRecordService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoRecordDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoRecord>)dao)
        {

        }

        #endregion
    }
}
