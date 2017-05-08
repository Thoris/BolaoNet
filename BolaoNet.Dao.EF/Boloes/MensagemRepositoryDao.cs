using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class MensagemRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.Mensagem>, Dao.Boloes.IMensagemDao
    {
        
        #region Constructors/Destructors

        public MensagemRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
