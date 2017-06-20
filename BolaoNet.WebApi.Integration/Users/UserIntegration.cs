using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Users
{
    public class UserIntegration :
        Base.GenericIntegration<Domain.Entities.Users.User>, 
        Domain.Interfaces.Services.Users.IUserService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "User";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public UserIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region IUserService members

        public Domain.Entities.Base.Common.Validation.ValidationResult Login(string userName, string password)
        {
             Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("userName", userName);
            parameters.Add("password", password);

            return base.HttpPostApi<Domain.Entities.Base.Common.Validation.ValidationResult>(parameters, "Login");      
        }

        public Domain.Entities.Base.Common.Validation.ValidationResult RegisterUser(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<Domain.Entities.Base.Common.Validation.ValidationResult>(
                new Dictionary<string, string>(), user, "RegisterUser");
        }

        public Domain.Entities.Base.Common.Validation.ValidationResult ChangePassword(string userName, string oldPassword, string newPassword, string confirmPassord)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("userName", userName);
            parameters.Add("oldPassword", oldPassword);
            parameters.Add("newPassword", newPassword);
            parameters.Add("confirmPassord", confirmPassord);

            return base.HttpPostApi<Domain.Entities.Base.Common.Validation.ValidationResult>(parameters, "ChangePassword");
       
        }

        public string GenerateActivationCode(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<string>(new Dictionary<string, string>(), user, "GenerateActivationCode");
        }

        public Domain.Entities.Base.Common.Validation.ValidationResult ApproveUser(Domain.Entities.Users.User user, string activationCode)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("user", user);
            parameters.Add("activationCode", activationCode);

            return base.HttpPostApi<Domain.Entities.Base.Common.Validation.ValidationResult>(parameters, "ApproveUser");
        }
        public IList<Domain.Entities.Users.User> SearchByUserNameEmail(string userName, string email)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("userName", userName);
            parameters.Add("email", email);

            return base.HttpPostApi<IList<Domain.Entities.Users.User>>(parameters, "SearchByUserNameEmail"); 
        }
        #endregion



    }
}
