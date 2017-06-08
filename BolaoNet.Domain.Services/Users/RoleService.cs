using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Users
{
    public class RoleService :
        Base.BaseGenericService<Entities.Users.Role>,
        Interfaces.Services.Users.IRoleService
    {
        #region Constructors/Destructors

        public RoleService(string userName, Interfaces.Repositories.Users.IRoleDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.Role>)dao)
        {

        }

        #endregion
    }
}
