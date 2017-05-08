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

        #region IApostaExtraDao members

        public bool InsertResult(string currentUserName, Entities.Boloes.ApostaExtra entry)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
