using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Facade
{
    public interface IUserFacadeBO
    {
        string GenerateActivationCode(Entities.Users.User user);
        bool CreateUser(Entities.Users.User user, params Entities.Users.Role [] roles);
        bool SendActivationCode(Entities.Users.User user);
        bool ActivateUser(Entities.Users.User user, string activationCode);
        bool SendRequestUserBolao(Entities.Users.User user, Entities.Boloes.Bolao bolao);
        bool ApproveRequestUserBolao(Entities.Boloes.BolaoRequest request);
    }
}
