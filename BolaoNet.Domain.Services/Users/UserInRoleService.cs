using BolaoNet.Domain.Interfaces.Services.Logging;
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

        public UserInRoleService(string userName, Interfaces.Repositories.Users.IUserInRoleDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.UserInRole>)dao, logging)
        {

        }

        #endregion
    }
}
