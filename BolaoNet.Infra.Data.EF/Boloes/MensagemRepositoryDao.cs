using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class MensagemRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.Mensagem>, Domain.Interfaces.Repositories.Boloes.IMensagemDao
    {
        
        #region Constructors/Destructors

        public MensagemRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
