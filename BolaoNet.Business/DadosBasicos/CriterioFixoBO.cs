using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.DadosBasicos
{
    public class CriterioFixoBO :
        Base.BaseGenericBusinessBO<Entities.DadosBasicos.CriterioFixo>,
        Interfaces.DadosBasicos.ICriterioFixoBO
    {
        #region Constructors/Destructors

        public CriterioFixoBO(string userName, Dao.DadosBasicos.ICriterioFixoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.DadosBasicos.CriterioFixo>)dao)
        {

        }

        #endregion
    }
}
