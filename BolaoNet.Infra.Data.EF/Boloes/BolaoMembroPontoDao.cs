using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoMembroPontoDao  :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoMembroPonto>,
        Domain.Interfaces.Repositories.Boloes.IBolaoMembroPontoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroPontoDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoMembroDao membros

        public IList<Domain.Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return null;
        }

        #endregion    
    

    }
}
