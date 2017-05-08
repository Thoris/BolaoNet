using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoGrupoTimeBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoGrupoTime>,
        Interfaces.Campeonatos.ICampeonatoGrupoTimeBO
    {
        #region Constructors/Destructors

        public CampeonatoGrupoTimeBO(string userName, Dao.Campeonatos.ICampeonatoGrupoTimeDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoGrupoTime>)dao)
        {

        }

        #endregion
    }
}
