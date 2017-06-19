using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Users
{
    public interface IUserService
        : Base.IGenericService<Entities.Users.User>
    {
        ValidationResult Login(string userName, string password);
        ValidationResult RegisterUser(Entities.Users.User user);
        ValidationResult ChangePassword(string userName, string oldPassword, string newPassword, string confirmPassord);
        string GenerateActivationCode(Entities.Users.User user);
        ValidationResult ApproveUser(Entities.Users.User user, string activationCode);
    }
}
