using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class ApostaExtraRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.ApostaExtra>, Dao.Boloes.IApostaExtraDao
    {

        #region Constructors/Destructors

        public ApostaExtraRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
