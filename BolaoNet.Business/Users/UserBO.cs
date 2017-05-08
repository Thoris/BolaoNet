using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Users
{
    public class UserBO :
        Base.BaseGenericBusinessBO<Entities.Users.User>,
        Interfaces.Users.IUserBO
    {
        #region Constructors/Destructors

        public UserBO(string userName, Dao.Users.IUserDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Users.User>)dao)
        {

        }

        #endregion
    }
}
