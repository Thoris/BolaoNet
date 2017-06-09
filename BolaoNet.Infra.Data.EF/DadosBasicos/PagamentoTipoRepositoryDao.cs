using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.DadosBasicos
{
    public class PagamentoTipoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.DadosBasicos.PagamentoTipo>, Domain.Interfaces.Repositories.DadosBasicos.IPagamentoTipoDao
    {
        
        #region Constructors/Destructors

        public PagamentoTipoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
