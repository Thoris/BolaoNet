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

        }

        #endregion

        #region IUserFacadeBO members

        public bool CreateUser(Entities.Users.User user)
        {
            throw new NotImplementedException();
        }

        public bool SendActivationCode(Entities.Users.User user)
        {
            throw new NotImplementedException();
        }

        public bool ActivateUser(Entities.Users.User user, string activationCode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
