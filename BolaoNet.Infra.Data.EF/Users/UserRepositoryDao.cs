using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Users
{
    public class UserRespositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Users.User>, 
        Domain.Interfaces.Repositories.Users.IUserDao
    {
        
        #region Constructors/Destructors

        public UserRespositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IUserDao members
        
        public IList<Domain.Entities.Users.User> SearchByUserNameEmail(string currentUserName, string userName, string email)
        {
            return base.GetList(
                x => string.Compare(x.UserName, userName, true) == 0 &&
                string.Compare(x.Email, email, true) == 0
                ).ToList<Domain.Entities.Users.User>();
        }

        #endregion
    }
}
