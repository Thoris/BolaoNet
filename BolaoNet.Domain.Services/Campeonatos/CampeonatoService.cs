using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoService :
        Base.BaseGenericService<Entities.Campeonatos.Campeonato>,
        Interfaces.Services.Campeonatos.ICampeonatoService
    {

        #region Constructors/Destructors

        public CampeonatoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.Campeonato>)dao)
        {

        }

        #endregion
    }
}
