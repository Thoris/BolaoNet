using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class GrupoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.Grupo>,
        Interfaces.Campeonatos.IGrupoBO
    {
        #region Constructors/Destructors

        public GrupoBO(string userName, Dao.Campeonatos.IGrupoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Grupo>)dao)
        {

        }

        #endregion
    }
}
