using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Users
{
    public class UserInRoleService :
        Base.BaseGenericService<Entities.Users.UserInRole>,
        Interfaces.Services.Users.IUserInRoleService
    {
        #region Constructors/Destructors

        public UserInRoleService(string userName, Interfaces.Repositories.Users.IUserInRoleDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.UserInRole>)dao)
        {

        }

        #endregion
    }
}
