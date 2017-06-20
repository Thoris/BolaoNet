using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Users
{
    public class UserApp :
        Base.GenericApp<Domain.Entities.Users.User>,
        Application.Interfaces.Users.IUserApp
    {
        #region Properties

        private Domain.Interfaces.Services.Users.IUserService Service
        {
            get { return (Domain.Interfaces.Services.Users.IUserService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserApp" />.
        /// </summary>
        public UserApp(Domain.Interfaces.Services.Users.IUserService service)
            : base (service)
        {

        }

        #endregion

        #region IUserApp members

        public Domain.Entities.Base.Common.Validation.ValidationResult Login(string userName, string password)
        {
            return this.Service.Login(userName, password);
        }

        public Domain.Entities.Base.Common.Validation.ValidationResult RegisterUser(Domain.Entities.Users.User user)
        {
            return Service.RegisterUser(user);
        }

        public Domain.Entities.Base.Common.Validation.ValidationResult ChangePassword(string userName, string oldPassword, string newPassword, string confirmPassord)
        {
            return Service.ChangePassword(userName, oldPassword, newPassword, confirmPassord);
        }

        public string GenerateActivationCode(Domain.Entities.Users.User user)
        {
            return Service.GenerateActivationCode(user);
        }

        public Domain.Entities.Base.Common.Validation.ValidationResult ApproveUser(Domain.Entities.Users.User user, string activationCode)
        {
            return Service.ApproveUser(user, activationCode);
        }
        public IList<Domain.Entities.Users.User> SearchByUserNameEmail(string userName, string email)
        {
            return Service.SearchByUserNameEmail(userName, email);
        }

        #endregion



    }
}
