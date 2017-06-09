using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.DadosBasicos
{
    public class EstadioRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.DadosBasicos.Estadio>, Domain.Interfaces.Repositories.DadosBasicos.IEstadioDao
    {
        
        #region Constructors/Destructors

        public EstadioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
