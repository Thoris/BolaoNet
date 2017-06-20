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
        #region Properties

        private Interfaces.Repositories.Users.IUserInRoleDao Dao
        {
            get { return (Interfaces.Repositories.Users.IUserInRoleDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public UserInRoleService(string userName, Interfaces.Repositories.Users.IUserInRoleDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.UserInRole>)dao, logging)
        {

        }

        #endregion

        #region IUserInRoleService members

        public IList<Entities.Users.Role> GetRolesInUser(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");
            
            return Dao.GetRolesInUser(base.CurrentUserName, user);
        }

        #endregion
    }
}
