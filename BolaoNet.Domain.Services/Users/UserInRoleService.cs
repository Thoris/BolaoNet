using BolaoNet.Domain.Entities.Users;
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

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Users.Role> res = Dao.GetRolesInUser(base.CurrentUserName, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de roles do usuário [" + user.UserName + "] total: " + res.Count));
            }

            return res;
        }

        public IList<User> GetUsersInRole(Role role)
        {
            if (role == null)
                throw new ArgumentException("role");
            if (string.IsNullOrEmpty(role.RoleName))
                throw new ArgumentException("role.RoleName");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Users.User> res = Dao.GetUsersInRole(base.CurrentUserName, role);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de usuários da role [" + role.RoleName + "] total: " + res.Count));
            }

            return res;
        }

        #endregion
    }
}
