using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoGrupoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoGrupo>,
        Interfaces.Campeonatos.ICampeonatoGrupoBO
    {
        #region Constructors/Destructors

        public CampeonatoGrupoBO(string userName, Dao.Campeonatos.ICampeonatoGrupoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoGrupo>)dao)
        {

        }

        #endregion
    }
}
