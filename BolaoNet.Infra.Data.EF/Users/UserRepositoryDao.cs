using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Users
{
    public class UserRespositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Users.User>, Domain.Interfaces.Repositories.Users.IUserDao
    {
        
        #region Constructors/Destructors

        public UserRespositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
