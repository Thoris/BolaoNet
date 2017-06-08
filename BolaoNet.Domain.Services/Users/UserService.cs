using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Users
{
    public class UserService :
        Base.BaseGenericService<Entities.Users.User>,
        Interfaces.Services.Users.IUserService
    {
        #region Constructors/Destructors

        public UserService(string userName, Interfaces.Repositories.Users.IUserDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.User>)dao)
        {

        }

        #endregion
    }
}
