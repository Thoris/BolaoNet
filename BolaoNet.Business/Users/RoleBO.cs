using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Users
{
    public class RoleBO :
        Base.BaseGenericBusinessBO<Entities.Users.Role>,
        Interfaces.Users.IRoleBO
    {
        #region Constructors/Destructors

        public RoleBO(string userName, Dao.Users.IRoleDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Users.Role>)dao)
        {

        }

        #endregion
    }
}
