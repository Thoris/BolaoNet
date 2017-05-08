using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Users
{
    public class UserInRoleRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Users.UserInRole>, Dao.Users.IUserInRoleDao
    {
        
        #region Constructors/Destructors

        public UserInRoleRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
