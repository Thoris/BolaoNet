using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.DadosBasicos
{
    public class PagamentoTipoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.DadosBasicos.PagamentoTipo>, Dao.DadosBasicos.IPagamentoTipoDao
    {
        
        #region Constructors/Destructors

        public PagamentoTipoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
