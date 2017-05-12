using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade
{
    public class UserFacadeBO : Interfaces.Facade.IUserFacadeBO
    {
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
