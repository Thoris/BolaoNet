using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.DadosBasicos
{
    public class PagamentoTipoBO :
        Base.BaseGenericBusinessBO<Entities.DadosBasicos.PagamentoTipo>,
        Interfaces.DadosBasicos.IPagamentoTipoBO
    {
        #region Constructors/Destructors

        public PagamentoTipoBO(string userName, Dao.DadosBasicos.IPagamentoTipoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.DadosBasicos.PagamentoTipo>)dao)
        {

        }

        #endregion
    }
}
