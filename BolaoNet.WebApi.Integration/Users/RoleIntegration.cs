using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Users
{
    public class RoleIntegration :
        Base.GenericIntegration<Domain.Entities.Users.Role>, 
        Domain.Interfaces.Services.Users.IRoleService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Role";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="RoleIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public RoleIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion
    }
}
