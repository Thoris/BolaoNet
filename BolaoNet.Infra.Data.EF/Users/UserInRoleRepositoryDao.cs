using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Users
{
    public class UserInRoleRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Users.UserInRole>, Domain.Interfaces.Repositories.Users.IUserInRoleDao
    {
        
        #region Constructors/Destructors

        public UserInRoleRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
