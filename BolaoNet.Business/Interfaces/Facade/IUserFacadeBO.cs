using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Facade
{
    public interface IUserFacadeBO
    {
        bool CreateUser(Entities.Users.User user);
        bool SendActivationCode(Entities.Users.User user);
        bool ActivateUser(Entities.Users.User user, string activationCode);
    }
}
