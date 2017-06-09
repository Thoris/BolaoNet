using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Users
{
    public class UserInRoleIntegration :
        Base.GenericIntegration<Domain.Entities.Users.UserInRole>, 
        Domain.Interfaces.Services.Users.IUserInRoleService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "User";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserInRoleIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public UserInRoleIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
