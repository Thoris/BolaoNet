using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Users
{
    public class UserRespositoryDao : 
        Base.BaseRepositoryDao<Entities.Users.User>, Dao.Users.IUserDao
    {
        
        #region Constructors/Destructors

        public UserRespositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
