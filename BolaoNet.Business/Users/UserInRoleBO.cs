using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Users
{
    public class UserInRoleBO :
        Base.BaseGenericBusinessBO<Entities.Users.UserInRole>,
        Interfaces.Users.IUserInRoleBO
    {
        #region Constructors/Destructors

        public UserInRoleBO(string userName, Dao.Users.IUserInRoleDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Users.UserInRole>)dao)
        {

        }

        #endregion
    }
}
