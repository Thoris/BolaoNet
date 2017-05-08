using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.DadosBasicos
{
    public class EstadioRepositoryDao : 
        Base.BaseRepositoryDao<Entities.DadosBasicos.Estadio>, Dao.DadosBasicos.IEstadioDao
    {
        
        #region Constructors/Destructors

        public EstadioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
