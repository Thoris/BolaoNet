using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Users
{
    public class RoleApp :
        Base.GenericApp<Domain.Entities.Users.Role>, 
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
        /// Inicializa nova instância da classe <see cref="RoleApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public RoleApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
