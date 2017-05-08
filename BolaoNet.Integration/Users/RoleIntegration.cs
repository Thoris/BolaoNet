using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Users
{
    public class RoleIntegration :
        Base.GenericIntegration<Entities.Users.Role>, 
        Business.Interfaces.Users.IRoleBO
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
        public RoleIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
