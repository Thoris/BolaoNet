using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.DadosBasicos
{
    public class EstadioBO :
        Base.BaseGenericBusinessBO<Entities.DadosBasicos.Estadio>,
        Interfaces.DadosBasicos.IEstadioBO
    {
        #region Constructors/Destructors

        public EstadioBO(string userName, Dao.DadosBasicos.IEstadioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.DadosBasicos.Estadio>)dao)
        {

        }

        #endregion
    }
}
