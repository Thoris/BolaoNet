using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class FaseBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.Fase>,
        Interfaces.Campeonatos.IFaseBO
    {
        #region Constructors/Destructors

        public FaseBO(string userName, Dao.Campeonatos.IFaseDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Fase>)dao)
        {

        }

        #endregion
    }
}
