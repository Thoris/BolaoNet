using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoTimeService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoTime>,
        Interfaces.Services.Campeonatos.ICampeonatoTimeService
    {
        #region Constructors/Destructors

        public CampeonatoTimeService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoTime>)dao)
        {

        }

        #endregion
    }
}
