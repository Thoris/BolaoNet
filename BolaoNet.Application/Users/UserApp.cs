using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Users
{
    public class UserApp :
        Base.GenericApp<Domain.Entities.Users.User>, 
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
        /// Inicializa nova instância da classe <see cref="UserApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public UserApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
