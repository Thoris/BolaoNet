using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade
{
    public class UserFacadeBO : Interfaces.Facade.IUserFacadeBO
    {
        #region Variables

        private Interfaces.Users.IUserBO _userBO;
        private Interfaces.Users.IUserInRoleBO _userInRoleBO;

        #endregion

        #region Constructors/Destructors

        public UserFacadeBO(Interfaces.IFactoryBO factory)
        {
            _userBO = factory.CreateUserBO();
            _userInRoleBO = factory.CreateUserInRoleBO();

        }

        #endregion

        #region IUserFacadeBO members

        public bool CreateUser(Entities.Users.User user)
        {
            long res = _userBO.Insert(user);

            if (res > 0)
                return true;
            else
                return false;

        }

        public bool SendActivationCode(Entities.Users.User user)
        {
            return true;
        }

        public bool ActivateUser(Entities.Users.User user, string activationCode)
        {
            return true;
        }

        #endregion
    }
}
