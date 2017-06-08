using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoFaseService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoFase>,
        Interfaces.Services.Campeonatos.ICampeonatoFaseService
    {
        #region Constructors/Destructors

        public CampeonatoFaseService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoFase>)dao)
        {

        }

        #endregion
    }
}
